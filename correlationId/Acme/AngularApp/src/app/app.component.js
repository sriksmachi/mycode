var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewEncapsulation } from '@angular/core';
import { Configuration } from './app.constants';
var AppComponent = (function () {
    function AppComponent(configuration) {
        this.configuration = configuration;
    }
    AppComponent.prototype.ngAfterViewInit = function () {
        var appInsights = window.appInsights || function (config) {
            var t = { config: config, version: "1", queue: [], cookie: "" }, u = document, e = window, o = "script", s = "AuthenticatedUserContext", h = "start", c = "stop", l = "Track", a = l + "Event", v = l + "Page", r, f;
            function i(config) {
                t[config] = function () {
                    var i = arguments;
                    t.queue.push(function () {
                        t[config].apply(t, i);
                    });
                };
            }
            var y = document.createElement("script");
            y.src = config.url;
            u.getElementsByTagName(o)[0].parentNode.appendChild(y);
            try {
                t.cookie = u.cookie;
            }
            catch (p) {
            }
            for (t.queue = [], t.version = "1.0", r = ["Event", "Exception", "Metric", "PageView", "Trace", "Dependency"]; r.length;)
                i("track" + r.pop());
            return i("set" + s), i("clear" + s), i(h + a), i(c + a), i(h + v), i(c + v), i("flush"),
                config.disableExceptionTracking || (r = "onerror", i("_" + r), f = e[r], e.onerror = function (config, i, u, e, o) {
                    var s = f && f(config, i, u, e, o);
                    return s !== !0 && t["_" + r](config, i, u, e, o), s;
                }), t;
        }({
            instrumentationKey: this.configuration.appInsightsInstrumentationKey.trim(), url: "/lib/ai.0.js",
            disableExceptionTracking: false, disableCorrelationHeaders: false
        });
        window.appInsights = appInsights;
        appInsights.trackPageView();
    };
    AppComponent = __decorate([
        Component({
            selector: 'app-component',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.css'],
            encapsulation: ViewEncapsulation.None
        }),
        __metadata("design:paramtypes", [Configuration])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map