@file:Suppress("PackageDirectoryMismatch")
package com.chartboost.mediation.unity.logging

interface UnityLoggingObserver {
    fun onBridgeLog(logMessage: String, logLevel:Int)

    fun onBridgeException(exception: String)
}
