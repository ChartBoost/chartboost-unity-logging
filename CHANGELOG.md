# Changelog
All notable changes to this project will be documented in this file using the standards as defined at [Keep a Changelog](https://keepachangelog.com/en/1.0.0/). This project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0).

### Version 1.1.0 *(2024-09-19)*
Added:
- Support to native wrapper logs through `UnityLoggingBridge`.
- `WrapperMessageLogged` event listener in `LogController` class. Use to listen for any log events communicated between Unity and native layers.

### Version 1.0.0 *(2024-08-01)*
First version of Chartboost Logging Utilities package for Unity.

Added:

- `LogController.cs` centralized log controller used by all Chartboost Unity Logs.
- `LogLevel` enum indicating current log filterling level.