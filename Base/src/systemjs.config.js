/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': '/node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            'app': 'app',

            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.min.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.min.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.min.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.min.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.min.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.min.js',
            '@angular/common/http': 'npm:@angular/common/bundles/common-http.umd.min.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.min.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.min.js',
            //cdk
            '@angular/cdk': 'npm:@angular/cdk/bundles/cdk.umd.min.js',
            '@angular/cdk/a11y': 'npm:@angular/cdk/bundles/cdk-a11y.umd.min.js',
            '@angular/cdk/bidi': 'npm:@angular/cdk/bundles/cdk-bidi.umd.min.js',
            '@angular/cdk/coercion': 'npm:@angular/cdk/bundles/cdk-coercion.umd.min.js',
            '@angular/cdk/collections': 'npm:@angular/cdk/bundles/cdk-collections.umd.min.js',
            '@angular/cdk/keycodes': 'npm:@angular/cdk/bundles/cdk-keycodes.umd.min.js',
            '@angular/cdk/observers': 'npm:@angular/cdk/bundles/cdk-observers.umd.min.js',
            '@angular/cdk/overlay': 'npm:@angular/cdk/bundles/cdk-overlay.umd.min.js',
            '@angular/cdk/platform': 'npm:@angular/cdk/bundles/cdk-platform.umd.min.js',
            '@angular/cdk/portal': 'npm:@angular/cdk/bundles/cdk-portal.umd.min.js',
            '@angular/cdk/rxjs': 'npm:@angular/cdk/bundles/cdk-rxjs.umd.min.js',
            '@angular/cdk/table': 'npm:@angular/cdk/bundles/cdk-table.umd.min.js',
            '@angular/cdk/scrolling': 'npm:@angular/cdk/bundles/cdk-scrolling.umd.min.js',
            '@angular/cdk/stepper': 'npm:@angular/cdk/bundles/cdk-stepper.umd.min.js', 

            // material and animation
            '@angular/animations': 'npm:@angular/animations/bundles/animations.umd.min.js',
            '@angular/animations/browser': 'npm:@angular/animations/bundles/animations-browser.umd.min.js',
            '@angular/platform-browser/animations': 'npm:@angular/platform-browser/bundles/platform-browser-animations.umd.min.js',
            '@angular/material': 'npm:@angular/material/bundles/material.umd.min.js',

            // other libraries
            'hammerjs': 'npm:hammerjs/hammer.js',
            'rxjs': 'npm:rxjs',
            'angular-in-memory-web-api': 'npm:angular-in-memory-web-api/bundles/in-memory-web-api.umd.min.js',
            'ng2-bs3-modal': 'npm:ng2-bs3-modal',
            'tslib': 'npm:tslib/tslib.js'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                defaultExtension: 'js',
                meta: {
                    './*.js': {
                        loader: 'systemjs-angular-loader.js'
                    }
                }
            },
            rxjs: {
                defaultExtension: 'js'
            },
            'ng2-bs3-modal': {
                main: '/bundles/ng2-bs3-modal.js',
                defaultExtension: 'js'
            }
        }
    });
})(this);
