let gulp = require('gulp');
let gulp_sass = require('gulp-sass')(require('sass'));

let filePaths = {
    sassInputPath: "./Content/css/**/*.scss",
    sassOutputPath: "./Content/css",
};

gulp.task('build-sass', () => {
    return gulp.src(filePaths.sassInputPath)
        .pipe(gulp_sass())
        .pipe(gulp.dest(filePaths.sassOutputPath));
});

exports.default = gulp.series('build-sass');