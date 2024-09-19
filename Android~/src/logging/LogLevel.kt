@file:Suppress("PackageDirectoryMismatch")
package com.chartboost.mediation.unity.logging

enum class LogLevel(var value: Int) {
    DISABLED(0),
    ERROR(1),
    WARNING(2),
    INFO(3),
    DEBUG(4),
    VERBOSE(5);

    companion object {
        /**
         * Get the log level corresponding to the integer value or VERBOSE if nothing matches.
         *
         * @param logLevelInt Integer representation of the log level.
         */
        fun fromInt(logLevelInt: Int?): LogLevel = entries.find { it.value == logLevelInt } ?: VERBOSE
    }
}
