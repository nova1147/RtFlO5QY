// 代码生成时间: 2025-08-22 15:29:51
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using Quartz.Impl;

// 定时任务调度器
public class ScheduledTaskManager : IHostedService, IDisposable
{
    private readonly IScheduler _scheduler;
    private readonly IServiceProvider _serviceProvider;
    private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();

    public ScheduledTaskManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        // 创建调度器工厂
        var schedulerFactory = new StdSchedulerFactory();
        // 获取调度器
        _scheduler = schedulerFactory.GetScheduler();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // 启动调度器
        _scheduler.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // 当取消令牌被触发时，停止调度器
        _stoppingCts.Cancel();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        // 停止并释放调度器资源
        _scheduler.Shutdown();
    }

    // 注册任务
    public void RegisterJob<T>(string cronExpression, string jobKey) where T : IJob
    {
        // 获取任务类型
        var jobType = typeof(T);

        // 创建任务定义
        var job = JobBuilder.Create<T>()
            .WithIdentity(jobKey, jobType.Namespace)
            .Build();

        // 创建触发器
        var trigger = TriggerBuilder.Create()
            .WithCronSchedule(cronExpression)
            .Build();

        // 将任务和触发器添加到调度器
        _scheduler.ScheduleJob(job, trigger);
    }
}

// 实现IJob接口的任务
public interface IScheduledTask : IJob
{
    // 任务执行方法
    void Execute();
}

// 示例任务
public class SampleTask : IScheduledTask
{
    private readonly ILogger<SampleTask> _logger;

    public SampleTask(ILogger<SampleTask> logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        // 执行任务逻辑
        _logger.LogInformation("SampleTask executed at: {time}", DateTime.Now);
    }

    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Execute();
        return Task.CompletedTask;
    }
}
