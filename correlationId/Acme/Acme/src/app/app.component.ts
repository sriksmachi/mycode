import { Component, ViewEncapsulation } from '@angular/core';
import { Configuration } from './app.constants';

@Component({
    selector: 'app-component',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None
})

export class AppComponent {

    constructor(private configuration: Configuration) { }

    public ngAfterViewInit() {
        //var appInsights = (<any>window).appInsights || function (config) {
        //    var t = { config: config, version: "1", queue: [], cookie: "" },
        //        u = document,
        //        e = window,
        //        o = "script",
        //        s = "AuthenticatedUserContext",
        //        h = "start",
        //        c = "stop",
        //        l = "Track",
        //        a = l + "Event",
        //        v = l + "Page",
        //        r, f;

        //    function i(config) {
        //        t[config] = function () {
        //            var i = arguments;
        //            t.queue.push(function () {
        //                t[config].apply(t, i)
        //            })
        //        }
        //    }

        //    var y = document.createElement("script");
        //    y.src = config.url;
        //    u.getElementsByTagName(o)[0].parentNode.appendChild(y);
        //    try {
        //        t.cookie = u.cookie
        //    }
        //    catch (p) {
        //    }
        //    for (t.queue = [], t.version = "1.0", r = ["Event", "Exception", "Metric", "PageView", "Trace", "Dependency"]; r.length;)
        //        i("track" + r.pop());
        //    return i("set" + s), i("clear" + s), i(h + a), i(c + a), i(h + v), i(c + v), i("flush"),
        //        config.disableExceptionTracking || (r = "onerror", i("_" + r), f = e[r], e.onerror = function (config, i, u, e, o) {
        //            var s = f && f(config, i, u, e, o); return s !== !0 && t["_" + r](config, i, u, e, o), s
        //        }), t
        //}
        //    ({
        //        instrumentationKey: this.configuration.appInsightsInstrumentationKey.trim(), url: "/lib/ai.0.js",
        //        disableExceptionTracking: false, disableCorrelationHeaders: false
        //    });
        //(<any>window).appInsights = appInsights;
        //appInsights.trackPageView();
    }
}
