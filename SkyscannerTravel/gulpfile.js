/// <binding BeforeBuild='sass' />
'use strict'

var gulp = require('gulp'),
    sass = require('gulp-sass');

gulp.task('sass', function () {
    return gulp.src('scss/main.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'))
});

gulp.task('watch', ['sass'], function () {
    gulp.watch('Scss/**/*.scss', ['sass']);
});