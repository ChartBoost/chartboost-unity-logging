@file:Suppress("PackageDirectoryMismatch")
package com.chartboost.mediation.unity.logging

import android.util.Log

class UnityLoggingBridge {

    companion object {

        private var loggingObserver: UnityLoggingObserver? = null
        private var logLevel: LogLevel = LogLevel.INFO

        @Suppress("unused")

        @JvmStatic
        fun setUnityLoggingObserver(loggingObserver: UnityLoggingObserver) {
            this.loggingObserver = loggingObserver
        }

        @Suppress("unused")
        @JvmStatic
        fun setLogLevel(logLevel: Int){
            this.logLevel = LogLevel.fromInt(logLevel)
        }

        @Suppress("unused")
        @JvmStatic
        fun getLogLevel(): Int {
            return logLevel.value
        }

        fun log(tag: String?, message: String, logLevel: LogLevel){
            if (this.logLevel == LogLevel.DISABLED)
                return

            if (logLevel > this.logLevel) {
                return
            }

            when (logLevel) {
                LogLevel.WARNING -> Log.w(tag, message)
                LogLevel.DEBUG -> Log.d(tag, message)
                LogLevel.INFO -> Log.i(tag, message)
                LogLevel.VERBOSE -> Log.v(tag, message)
                LogLevel.ERROR -> Log.e(tag, message)
                LogLevel.DISABLED -> return
            }

            loggingObserver?.onBridgeLog("$tag $message", logLevel.value)
        }

        fun logException(tag: String?, exception: String){
            Log.e(tag, exception)
            loggingObserver?.onBridgeException("$tag $exception")
        }
    }
}
