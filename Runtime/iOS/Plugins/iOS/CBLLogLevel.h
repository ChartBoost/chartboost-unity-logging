#import <objc/runtime.h>
#import <Foundation/Foundation.h>

typedef NS_ENUM(NSUInteger, CBLLogLevel){
    CBLLogLevelDisabled = 0,
    CBLLogLevelError = 1,
    CBLLogLevelWarning = 2,
    CBLLogLevelInfo = 3,
    CBLLogLevelDebug = 4,
    CBLLogLevelVerbose = 5
};
