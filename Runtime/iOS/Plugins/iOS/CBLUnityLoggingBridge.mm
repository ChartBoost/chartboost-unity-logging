#import "CBLUnityLoggingBridge.h"

@implementation CBLUnityLoggingBridge

+ (instancetype)sharedLogger {
    static dispatch_once_t pred = 0;
    static id _sharedObject = nil;

    dispatch_once(&pred, ^{
        _sharedObject = [[self alloc] init];
        [_sharedObject setLogLevel: CBLLogLevelInfo];
        [_sharedObject setLogger:os_log_create("CBLUnityLoggingBridge", "wrappers")];
    });

    return _sharedObject;
}

- (void)logWithTag:(NSString *)tag log:(NSString *)message logLevel:(CBLLogLevel)logLevel {
    if (_logLevel == CBLLogLevelDisabled)
        return;

    if (logLevel > _logLevel)
        return;

    NSString* taggedMessage = [NSString stringWithFormat:@"%@ %@", tag, message];

    switch (_logLevel) {
        case CBLLogLevelDisabled:
            return;
        case CBLLogLevelError:
            [self logWithType:OS_LOG_TYPE_ERROR message:taggedMessage];
        case CBLLogLevelWarning:
            [self logWithType:OS_LOG_TYPE_DEFAULT message:taggedMessage];
        case CBLLogLevelInfo:
            [self logWithType:OS_LOG_TYPE_INFO message:taggedMessage];
        case CBLLogLevelDebug:
        case CBLLogLevelVerbose:
            [self logWithType:OS_LOG_TYPE_DEBUG message:taggedMessage];
            break;
    }

    if (_onBridgeMessageLogged != nil)
        _onBridgeMessageLogged(toCStringOrNull(taggedMessage), (int)_logLevel);
}


- (void)logExceptionWithTag:(NSString *)tag exception:(NSString *)exceptionMessage {
    NSString* taggedMessage = [NSString stringWithFormat:@"%@ %@", tag, exceptionMessage];
    [self logWithType:OS_LOG_TYPE_FAULT message:taggedMessage];
    if (_onExceptionLogged != nil)
        _onExceptionLogged(toCStringOrNull(taggedMessage));
}

- (void)logWithType:(os_log_type_t)type message:(NSString*) message {
    os_log_with_type(_logger, type, "%{public}@", message);
}

@end

extern "C" {
    void _CBLSetUnityLoggingCallbacks(CBLBridgeMessageLogged bridgeMessageLoggedCallback, CBLExceptionLogged exceptionLoggedCallback){
        [[CBLUnityLoggingBridge sharedLogger] setOnBridgeMessageLogged:bridgeMessageLoggedCallback];
        [[CBLUnityLoggingBridge sharedLogger] setOnExceptionLogged:exceptionLoggedCallback];
    }

    void _CBLSetLogLevel(int logLevel){
        [[CBLUnityLoggingBridge sharedLogger] setLogLevel:(CBLLogLevel)logLevel];
    }

    int _CBLGetLogLevel(){
        return (int)[[CBLUnityLoggingBridge sharedLogger] logLevel];
    }
}
