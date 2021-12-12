using System.Diagnostics;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Abstractions;
using DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Options;

namespace DotnetAppMetricsPrototype.Application.PerformanceMonitoring.Services
{
    public class ClrMetricsService : IHostedService
    {
        private static readonly TimeSpan TimerInterval = TimeSpan.FromSeconds(5);
        private readonly IAppMonitoring _appMonitoring;
        private GcEventListener? _gcEventListener;
        private readonly Process _process;
        private readonly Timer _timer;

        public ClrMetricsService(IAppMonitoring appMonitoring)
        {
            _appMonitoring = appMonitoring;
            _process = Process.GetCurrentProcess();
            _timer = new Timer(OnTimer!);
        }

        private void OnTimer(object state) =>
            _appMonitoring.SetPhysicalMemory(_process.WorkingSet64);

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer.Change(TimerInterval, TimerInterval);
            _gcEventListener = new GcEventListener(_appMonitoring);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _gcEventListener?.Dispose();
            return Task.CompletedTask;
        }
    }
}