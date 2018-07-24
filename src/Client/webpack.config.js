var path = require("path");
var webpack = require("webpack");
var fableUtils = require("fable-utils");

function resolve(filePath) {
    return path.join(__dirname, filePath)
}

var babelOptions = fableUtils.resolveBabelOptions({
    presets: [
        ["env", {
            "targets": {
                "browsers": ["last 2 versions"]
            },
            "modules": false
        }]
    ],
    plugins: ["transform-runtime"]
});


var isProduction = process.argv.indexOf("-p") >= 0;
var port = process.env.SUAVE_FABLE_PORT || "8085";
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
    devtool: "source-map",
    entry: resolve('./Client.fsproj'),
    mode: isProduction ? "production" : "development",
    output: {
        path: resolve('./public'),
        publicPath: "/public",
        filename: "bundle.js"
    },
    resolve: {
        modules: [resolve("../../node_modules/")]
    },
    devServer: {
        proxy: {
            '/api/*': {
                target: 'http://localhost:' + port,
                changeOrigin: true
            },
            '/wsbridge': {
                target: 'http://localhost:' + port,
                ws: true
            }
        },
        hot: true,
        inline: true,
        historyApiFallback: true,
    },
    module: {
        rules: [{
                test: /\.fs(x|proj)?$/,
                use: {
                    loader: "fable-loader",
                    options: {
                        babel: babelOptions,
                        define: isProduction ? [] : ["DEBUG"]
                    }
                }
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            },
            { test: /\.(png|woff|woff2|eot|ttf|svg)$/, loader: 'url-loader?limit=100000' },
            { test: /\.html$/, loader: "html" },
            // { test: /\.svg$/, loader: 'svg-loader?{png:{scale:2}}' },
            // { test: /\.(eot|woff)$/, loader: "file-loader" },
            {
                test: /\.js(x?)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: babelOptions
                },
            },
            {
                test: /\.ts(x?)$/,
                exclude: /node_modules/,
                use: [{
                        loader: 'babel-loader',
                        options: babelOptions
                    },
                    {
                        loader: 'ts-loader'
                    }
                ]
            },
            {
                test: /\.s(a|c)ss$/,
                use: [
                    "style-loader",
                    "css-loader",
                    "sass-loader"
                ]
            },
        ]
    },
    plugins: isProduction ? [] : [
        new webpack.HotModuleReplacementPlugin(),
        new webpack.NamedModulesPlugin()
    ]
};