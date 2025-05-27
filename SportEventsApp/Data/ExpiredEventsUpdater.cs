using SportEventsApp.Interfaces;

namespace SportEventsApp.Data
{
    public class ExpiredEventsUpdater : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ExpiredEventsUpdater(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var repository = scope.ServiceProvider.GetRequiredService<ISportEventRepository>();
                    await repository.UpdateExpiredEventsAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
