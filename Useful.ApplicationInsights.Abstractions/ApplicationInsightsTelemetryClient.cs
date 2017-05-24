using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;

namespace Useful.ApplicationInsights.Abstractions
{
    /// <summary>
    /// Class to wrap the Application Insights Telemetry Client to aid testability
    /// </summary>
    public class ApplicationInsightsTelemetryClient : IApplicationInsightsTelemetryClient
    {
        private readonly TelemetryClient _client;

        /// <summary>
        /// Initializes a new instance of the Microsoft.ApplicationInsights.TelemetryClient
        /// Send telemetry with the active configuration, usually loaded from ApplicationInsights.config
        /// </summary>
        public ApplicationInsightsTelemetryClient()
        {
            _client = new TelemetryClient();
        }

        /// <summary>
        /// Initializes a new instance of the Microsoft.ApplicationInsights.TelemetryClient
        ///  Send telemetry with the specified configuration.
        /// </summary>
        /// <param name="configuration">The telemetry configuration</param>
        public ApplicationInsightsTelemetryClient(TelemetryConfiguration configuration)
        {
            _client = new TelemetryClient(configuration);
        }

        /// <summary>
        /// Get/Set the Instrumentation Key
        /// </summary>
        public string InstrumentationKey
        {
            get => _client.InstrumentationKey;
            set => _client.InstrumentationKey = value;
        }

        /// <summary>
        ///  Flushes the in-memory buffer.
        /// </summary>
        public void Flush()
        {
            _client.Flush();
        }

        /// <summary>
        /// Check to determine if the tracking is enabled.
        /// </summary>
        /// <returns>A boolean denoting if the tracking is enabled</returns>
        public bool IsEnabled()
        {
            return _client.IsEnabled();
        }

        /// <summary>
        /// Send information about external dependency call in the application.
        /// </summary>
        /// <param name="dependencyTypeName">External dependency type</param>
        /// <param name="target">External dependency target</param>
        /// <param name="dependencyName">External dependency name</param>
        /// <param name="data">Dependency call command name</param>
        /// <param name="startTime">The time when the dependency was called</param>
        /// <param name="duration">The time taken by the external dependency to handle the call</param>
        /// <param name="resultCode">Result code of dependency call execution</param>
        /// <param name="success">True if the dependency call was handled successfully</param>
        public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
        {
            _client.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success);
        }

        /// <summary>
        /// Send information about external dependency call in the application. Create a
        /// separate Microsoft.ApplicationInsights.DataContracts.DependencyTelemetry instance
        /// for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackDependency(Microsoft.ApplicationInsights.DataContracts.DependencyTelemetry)
        /// </summary>
        /// <param name="telemetry">The dependency telemetry</param>
        public void TrackDependency(DependencyTelemetry telemetry)
        {
            _client.TrackDependency(telemetry);
        }

        /// <summary>
        /// Send information about external dependency call in the application.
        /// </summary>
        /// <param name="dependencyName">External dependency name</param>
        /// <param name="commandName">Dependency call command name</param>
        /// <param name="startTime">The time when the dependency was called</param>
        /// <param name="duration">The time taken by the external dependency to handle the call</param>
        /// <param name="success">True if the dependency call was handled successfully</param>
        public void TrackDependency(string dependencyName, string commandName, DateTimeOffset startTime, TimeSpan duration, bool success)
        {
            _client.TrackDependency(dependencyName, commandName, startTime, duration, success);
        }

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.EventTelemetry for display
        /// in Diagnostic Search and aggregation in Metrics Explorer.
        /// </summary>
        /// <param name="eventName">A name for the event</param>
        /// <param name="properties">(optional) Named string values you can use to search and classify events</param>
        /// <param name="metrics">(optional) Measurements associated with this event</param>
        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            _client.TrackEvent(eventName, properties, metrics);
        }

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.EventTelemetry for display
        /// in Diagnostic Search and aggregation in Metrics Explorer. Create a separate Microsoft.ApplicationInsights.DataContracts.EventTelemetry
        ///instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackEvent(Microsoft.ApplicationInsights.DataContracts.EventTelemetry)
        /// </summary>
        /// <param name="telemetry">An event log item</param>
        public void TrackEvent(EventTelemetry telemetry)
        {
            _client.TrackEvent(telemetry);
        }

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry for display
        /// in Diagnostic Search.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="properties">Named string values you can use to classify and search for this exception</param>
        /// <param name="metrics">Additional values associated with this exception</param>
        public void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            _client.TrackException(exception, properties, metrics);
        }

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry for display
        /// in Diagnostic Search. Create a separate Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry
        /// instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackException(Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry)
        /// </summary>
        /// <param name="telemetry">The exception telemetry</param>
        public void TrackException(ExceptionTelemetry telemetry)
        {
            _client.TrackException(telemetry);
        }
        
        /// <summary>
        /// Send a Microsoft.ApplicationInsights.DataContracts.MetricTelemetry for representing
        /// aggregated metric data. Create a separate Microsoft.ApplicationInsights.DataContracts.MetricTelemetry
        /// instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackMetric(Microsoft.ApplicationInsights.DataContracts.MetricTelemetry).
        /// </summary>
        /// <param name="telemetry">The metric telemetry</param>
        public void TrackMetric(MetricTelemetry telemetry)
        {
            _client.TrackMetric(telemetry);
        }

        /// <summary>
        /// Send a Microsoft.ApplicationInsights.DataContracts.MetricTelemetry for aggregation
        /// in Metric Explorer.
        /// </summary>
        /// <param name="name">Metric name</param>
        /// <param name="value">Metric value</param>
        /// <param name="properties">Named string values you can use to classify and filter metrics</param>
        public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
        {
            _client.TrackMetric(name, value, properties);
        }

        /// <summary>
        /// Send information about the page viewed in the application
        /// </summary>
        /// <param name="name">Name of the page</param>
        public void TrackPageView(string name)
        {
            _client.TrackPageView(name);
        }
        
        /// <summary>
        /// Send information about the page viewed in the application. Create a separate
        /// Microsoft.ApplicationInsights.DataContracts.PageViewTelemetry instance for each
        /// call to Microsoft.ApplicationInsights.TelemetryClient.TrackPageView(Microsoft.ApplicationInsights.DataContracts.PageViewTelemetry).
        /// </summary>
        /// <param name="telemetry">The page view telemetry</param>
        public void TrackPageView(PageViewTelemetry telemetry)
        {
            _client.TrackPageView(telemetry);
        }

        /// <summary>
        /// Send information about a request handled by the application
        /// </summary>
        /// <param name="name">The request name</param>
        /// <param name="startTime">The time when the page was requested</param>
        /// <param name="duration">The time taken by the application to handle the request</param>
        /// <param name="responseCode">The response status code</param>
        /// <param name="success">True if the request was handled successfully by the application</param>
        public void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
        {
            _client.TrackRequest(name, startTime, duration, responseCode, success);
        }

        /// <summary>
        /// Send information about a request handled by the application. Create a separate
        /// Microsoft.ApplicationInsights.DataContracts.RequestTelemetry instance for each
        /// call to Microsoft.ApplicationInsights.TelemetryClient.TrackRequest(Microsoft.ApplicationInsights.DataContracts.RequestTelemetry).
        /// </summary>
        /// <param name="request">The request telemetry</param>
        public void TrackRequest(RequestTelemetry request)
        {
            _client.TrackRequest(request);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search. Create a separate Microsoft.ApplicationInsights.DataContracts.TraceTelemetry
        /// instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackTrace(Microsoft.ApplicationInsights.DataContracts.TraceTelemetry).
        /// </summary>
        /// <param name="telemetry">The trace telemetry</param>
        public void TrackTrace(TraceTelemetry telemetry)
        {
            _client.TrackTrace(telemetry);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="severityLevel">Trace severity level</param>
        /// <param name="properties">Named string values you can use to search and classify events</param>
        public void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
        {
            _client.TrackTrace(message, severityLevel, properties);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="properties">Named string values you can use to search and classify events</param>
        public void TrackTrace(string message, IDictionary<string, string> properties)
        {
            _client.TrackTrace(message, properties);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="severityLevel">Trace severity level</param>
        public void TrackTrace(string message, SeverityLevel severityLevel)
        {
            _client.TrackTrace(message, severityLevel);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        public void TrackTrace(string message)
        {
            _client.TrackTrace(message);
        }
    }
}