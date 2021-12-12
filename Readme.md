# Dotnet App Metrics Prototype

## Sandbox Skaffolding

This project is a skaffold for App.Metrics using Postgres, Docker, InfluxDb, Telegraf, Chronograf, Prometheus, and Grafana.

## Housekeeping

Setting up a Sandbox to test out a package provides an isolated environment for working and experimenting with nuget packages, tools, technologies, etc. before adding it to an actual project. 

The project uses Clean Architecture, but for simplicity -- since it is just a quick prototype -- it does not separate the folder structures into separate library projects.
In a real project (depending on the size of the project), it may be worth making SharedKernel, Application, Domain, Presentation and Infrastructure their own proj; 
at the minimum, keep with isolating the folder directories using internal access modifiers to create a proper bounded context.

## AppSettings

"Metrics:Tags" will override Env and Server if provide keys of the same name in the tags ICollectionSection.

## Dev Notes 

### To Connect Grafana to InfluxDb use:

http://influxdb:8086 for the "URL"
Flux for the Query Language
And the values in the .env for InfluxDb Details

Prometheus is hooked in to AppMetrics and you can add the dashboard from the ~\infrastructure-provisioning\grafana\dashboards\app-metrics-web-monitoring-prometheus_rev4.json, 
but Prometheus is not exported to say ElasticSearch

### For chronograf (if you want to use it)

Make sure you Enable InfluxDb v2 Auth to ensure that Chronograf can connect to InfluxDb (add the organization, etc. like the others)

### Grafana Boards
https://grafana.com/grafana/dashboards/?search=app+metrics
