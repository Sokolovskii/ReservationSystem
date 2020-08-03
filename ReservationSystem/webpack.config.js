﻿const path = require("path");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");

const entryConfig = {
    main: [
        "./wwwroot/js/Main.ts"
    ]

}

module.exports = {
    entry: entryConfig,
    output: {
        path: path.resolve(__dirname, "wwwroot/TScompiled"),
        filename: "[name].bundle.js",
        sourceMapFilename: "[name].map",
        library: "[name]"
    },
    resolve: {
        extensions: [".ts"]
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: "ts-loader"
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin()
    ]
};