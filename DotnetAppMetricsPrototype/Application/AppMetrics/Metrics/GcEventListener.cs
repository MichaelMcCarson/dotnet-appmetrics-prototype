using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using App.Metrics;
using DotnetAppMetricsPrototype.Application.AppMetrics.Schemas;

namespace DotnetAppMetricsPrototype.Application.AppMetrics.Metrics
{
    public class GcEventListener : EventListener
    {
        private readonly IMetrics _metrics;

        public GcEventListener(IMetrics metrics) =>
            _metrics = metrics;

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (!eventSource.Name.Equals("Microsoft-Windows-DotNETRuntime"))
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
                    _metrics.SetThreadCount(newWorkerThreadCount);
                    break;
                case EventIds.ExceptionThrownV1:
                    _metrics.ExceptionThrown((string)eventData.Payload![0]!);
                    break;
            }
        }
    }
}