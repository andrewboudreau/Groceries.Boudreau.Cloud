/// <binding Clean='clean' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";


paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

paths.angularAppJsDest = paths.webroot + "app/**/*.js";
paths.angularAppJsMapDest = paths.webroot + "app/**/*.js.map";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, () => 
        rimraf(paths.angularAppJsDest, () =>
            rimraf(paths.angularAppJsMapDest, cb)));
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

// We are using bundleconfig.json for managing min & concat

//gulp.task("min:js", function () {
//    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
//        .pipe(concat(paths.concatJsDest))
//        .pipe(uglify()).pipe(gulp.dest("."));
//});

//gulp.task("min:css", function () {
//    return gulp.src([paths.css, "!" + paths.minCss])
//        .pipe(concat(paths.concatCssDest))
//        .pipe(cssmin())
//        .pipe(gulp.dest("."));
//});

//gulp.task("min", ["min:js", "min:css"]);

gulp.task('restore', function () {
    gulp.src([
        'node_modules/@angular/**/*.js',
        'node_modules/angular2-in-memory-web-api/*.js',
        'node_modules/rxjs/**/*.js',
        'node_modules/systemjs/dist/*.js',
        'node_modules/zone.js/dist/*.js',
        'node_modules/core-js/client/*.js',
        'node_modules/reflect-metadata/reflect.js',
        'node_modules/jquery/dist/*.js',
        'node_modules/bootstrap/dist/**/*.*'
    ]).pipe(gulp.dest('./wwwroot/libs'));
});