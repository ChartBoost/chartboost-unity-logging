#import <os/log.h>
#import "CBLLogLevel.h"
#import "ChartboostUnityUtilities.h"

typedef void (*CBLBridgeMessageLogged)(const char* message, int logLevel);
typedef void (*CBLExceptionLogged)(const char* exception);

@interface CBLUnityLoggingBridge : NSObject

+ (instancetype) sharedLogger;

- (void) logWithTag:(NSString*)tag log:(NSString*)message logLevel:(CBLLogLevel)logLevel;
- (void) logExceptionWithTag:(NSString*)tag exception:(NSString*)exceptionMessage;

@property os_log_t logger;
@property CBLLogLevel logLevel;
@property CBLBridgeMessageLogged onBridgeMessageLogged;
@property CBLExceptionLogged onExceptionLogged;

@end
