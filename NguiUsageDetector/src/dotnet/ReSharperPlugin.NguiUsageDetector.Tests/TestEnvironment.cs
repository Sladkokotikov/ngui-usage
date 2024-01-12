﻿using System.Threading;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[assembly: Apartment(ApartmentState.STA)]

namespace ReSharperPlugin.NguiUsageDetector.Tests
{
    [ZoneDefinition]
    public class NguiUsageDetectorTestEnvironmentZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>,
        IRequire<INguiUsageDetectorZone>
    {
    }

    [ZoneMarker]
    public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>,
        IRequire<NguiUsageDetectorTestEnvironmentZone>
    {
    }

    [SetUpFixture]
    public class NguiUsageDetectorTestsAssembly : ExtensionTestEnvironmentAssembly<NguiUsageDetectorTestEnvironmentZone>
    {
    }
}