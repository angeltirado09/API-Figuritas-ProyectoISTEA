var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Figuritas_Consumer>("figuritas-consumer");

builder.Build().Run();
