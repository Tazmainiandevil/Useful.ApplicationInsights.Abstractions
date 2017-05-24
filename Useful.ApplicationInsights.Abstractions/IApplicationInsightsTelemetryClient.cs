using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;

namespace Useful.ApplicationInsights.Abstractions
{
    /// <summary>
    /// Interface to wrap the Application Insights Telemetry Client
    /// </summary>
    public interface IApplicationInsightsTelemetryClient
    {
        /// <summary>
        /// Get/Set the Instrumentation Key
        /// </summary>
        string InstrumentationKey { get; set; }

        /// <summary>
        ///  Flushes the in-memory buffer.
        /// </summary>
        void Flush();

        /// <summary>
        /// Check to determine if the tracking is enabled.
        /// </summary>
        /// <returns>A boolean denoting if the tracking is enabled</returns>
        bool IsEnabled();

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
        void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success);

        /// <summary>
        /// Send information about external dependency call in the application. Create a
        /// separate Microsoft.ApplicationInsights.DataContracts.DependencyTelemetry instance
        /// for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackDependency(Microsoft.ApplicationInsights.DataContracts.DependencyTelemetry)
        /// </summary>
        /// <param name="telemetry">The dependency telemetry</param>
        void TrackDependency(DependencyTelemetry telemetry);

        /// <summary>
        /// Send information about external dependency call in the application.
        /// </summary>
        /// <param name="dependencyName">External dependency name</param>
        /// <param name="commandName">Dependency call command name</param>
        /// <param name="startTime">The time when the dependency was called</param>
        /// <param name="duration">The time taken by the external dependency to handle the call</param>
        /// <param name="success">True if the dependency call was handled successfully</param>
        void TrackDependency(string dependencyName, string commandName, DateTimeOffset startTime, TimeSpan duration, bool success);

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.EventTelemetry for display
        /// in Diagnostic Search and aggregation in Metrics Explorer.
        /// </summary>
        /// <param name="eventName">A name for the event</param>
        /// <param name="properties">(optional) Named string values you can use to search and classify events</param>
        /// <param name="metrics">(optional) Measurements associated with this event</param>
        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.EventTelemetry for display
        /// in Diagnostic Search and aggregation in Metrics Explorer. Create a separate Microsoft.ApplicationInsights.DataContracts.EventTelemetry
        ///instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackEvent(Microsoft.ApplicationInsights.DataContracts.EventTelemetry)
        /// </summary>
        /// <param name="telemetry">An event log item</param>
        void TrackEvent(EventTelemetry telemetry);

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry for display
        /// in Diagnostic Search.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="properties">Named string values you can use to classify and search for this exception</param>
        /// <param name="metrics">Additional values associated with this exception</param>
        void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

        /// <summary>
        /// Send an Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry for display
        /// in Diagnostic Search. Create a separate Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry
        /// instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackException(Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry)
        /// </summary>
        /// <param name="telemetry">The exception telemetry</param>
        void TrackException(ExceptionTelemetry telemetry);

        /// <summary>
        /// Send a Microsoft.ApplicationInsights.DataContracts.MetricTelemetry for representing
        /// aggregated metric data. Create a separate Microsoft.ApplicationInsights.DataContracts.MetricTelemetry
        /// instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackMetric(Microsoft.ApplicationInsights.DataContracts.MetricTelemetry).
        /// </summary>
        /// <param name="telemetry">The metric telemetry</param>
        void TrackMetric(MetricTelemetry telemetry);

        /// <summary>
        /// Send a Microsoft.ApplicationInsights.DataContracts.MetricTelemetry for aggregation
        /// in Metric Explorer.
        /// </summary>
        /// <param name="name">Metric name</param>
        /// <param name="value">Metric value</param>
        /// <param name="properties">Named string values you can use to classify and filter metrics</param>
        void TrackMetric(string name, double value, IDictionary<string, string> properties = null);

        /// <summary>
        /// Send information about the page viewed in the application
        /// </summary>
        /// <param name="name">Name of the page</param>
        void TrackPageView(string name);

        /// <summary>
        /// Send information about the page viewed in the application. Create a separate
        /// Microsoft.ApplicationInsights.DataContracts.PageViewTelemetry instance for each
        /// call to Microsoft.ApplicationInsights.TelemetryClient.TrackPageView(Microsoft.ApplicationInsights.DataContracts.PageViewTelemetry).
        /// </summary>
        /// <param name="telemetry">The page view telemetry</param>
        void TrackPageView(PageViewTelemetry telemetry);

        /// <summary>
        /// Send information about a request handled by the application
        /// </summary>
        /// <param name="name">The request name</param>
        /// <param name="startTime">The time when the page was requested</param>
        /// <param name="duration">The time taken by the application to handle the request</param>
        /// <param name="responseCode">The response status code</param>
        /// <param name="success">True if the request was handled successfully by the application</param>
        void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success);

        /// <summary>
        /// Send information about a request handled by the application. Create a separate
        /// Microsoft.ApplicationInsights.DataContracts.RequestTelemetry instance for each
        /// call to Microsoft.ApplicationInsights.TelemetryClient.TrackRequest(Microsoft.ApplicationInsights.DataContracts.RequestTelemetry).
        /// </summary>
        /// <param name="request">The request telemetry</param>
        void TrackRequest(RequestTelemetry request);

        /// <summary>
        /// Send a trace message for display in Diagnostic Search. Create a separate Microsoft.ApplicationInsights.DataContracts.TraceTelemetry
        /// instance for each call to Microsoft.ApplicationInsights.TelemetryClient.TrackTrace(Microsoft.ApplicationInsights.DataContracts.TraceTelemetry).
        /// </summary>
        /// <param name="telemetry">The trace telemetry</param>
        void TrackTrace(TraceTelemetry telemetry);

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="severityLevel">Trace severity level</param>
        /// <param name="properties">Named string values you can use to search and classify events</param>
        void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties);

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="properties">Named string values you can use to search and classify events</param>
        void TrackTrace(string message, IDictionary<string, string> properties);

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="severityLevel">Trace severity level</param>
        void TrackTrace(string message, SeverityLevel severityLevel);

        /// <summary>
        /// Send a trace message for display in Diagnostic Search
        /// </summary>
        /// <param name="message">Message to display</param>
        void TrackTrace(string message);
    }
}