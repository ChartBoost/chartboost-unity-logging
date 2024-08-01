# Chartboost Centralized Logging
Chartboost centralized logging system for Unity. Utilized by all Chartboost Unity packages.

# Installation
This package is meant to be a dependency for other Chartboost Packages; however, if you wish to use it by itself, it can be installed through UPM & NuGet as follows:

## Using the public [npm registry](https://www.npmjs.com/search?q=com.chartboost.unity.logging)
```json
"dependencies": {
    "com.chartboost.unity.logging": "1.0.0",
    ...
},
"scopedRegistries": [
{
    "name": "NpmJS",
    "url": "https://registry.npmjs.org",
    "scopes": [
    "com.chartboost"
    ]
}
]
```

## Using the public [NuGet package](https://www.nuget.org/packages/Chartboost.CSharp.Logging.Unity)

To add the Chartboost Core Unity SDK to your project using the NuGet package, you will first need to add the [NugetForUnity](https://github.com/GlitchEnzo/NuGetForUnity) package into your Unity Project.

This can be done by adding the following to your Unity Project's ***manifest.json***

```json
  "dependencies": {
    "com.github-glitchenzo.nugetforunity": "https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity",
    ...
  },
```

Once <code>NugetForUnity</code> is installed, search for `Chartboost.CSharp.Logging.Unity` in the search bar of Nuget Explorer window(Nuget -> Manage Nuget Packages).
You should be able to see the `Chartboost.CSharp.Logging.Unity` package. Choose the appropriate version and install.