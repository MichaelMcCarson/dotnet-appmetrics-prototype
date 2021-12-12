using System.Diagnostics.Tracing;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Schemas;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options
{
    internal class GcEventListener : EventListener
    {
        /// <summary>
        /// There are more event providers: https://docs.microsoft.com/en-us/dotnet/core/diagnostics/well-known-event-providers
        /// </summary>
        private const string DotnetRuntimeEventProvider = "Microsoft-Windows-DotNETRuntime";

        private readonly IAppMonitoring _appMonitoring;

        public GcEventListener(IAppMonitoring appMonitoring) =>
            _appMonitoring = appMonitoring;

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (!eventSource.Name.Equals(DotnetRuntimeEventProvider))
            {
                return;
            }

            EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)(-1));
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            switch ((EventIds)eventData.EventId)
            {
                case EventIds.ThreadPoolWorkerThreadAdjustmentAdjustment:
                    var newWorkerThreadCount = (uint)eventData.Payload![1]!;
                    _appMonitoring.SetThreadCount(newWorkerThreadCount);
                    break;
                case EventIds.ExceptionThrownV1:
                    _appMonitoring.ExceptionThrown((string)eventData.Payload![0]!);
                    break;
            }
        }
    }
}