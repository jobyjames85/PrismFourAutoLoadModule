using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace PrismFourAuto
{
    //public class CombinedModuleEnumerator : IModuleEnumerator
    //{
    //    private readonly IModuleEnumerator _directoryEnumerator;
    //    private readonly IModuleEnumerator _staticEnumerator;

    //    public CombinedModuleEnumerator(string path)
    //        : this(new StaticModuleEnumerator(),
    //               new DirectoryLookupModuleEnumerator(path))
    //    {
    //    }

    //    public CombinedModuleEnumerator(IModuleEnumerator staticEnumerator,
    //        IModuleEnumerator directoryEnumerator)
    //    {
    //        _staticEnumerator = staticEnumerator;
    //        _directoryEnumerator = directoryEnumerator;
    //    }

    //    public ModuleInfo[] GetModules()
    //    {
    //        ModuleInfo[] m1 = _directoryEnumerator.GetModules();
    //        ModuleInfo[] m2 = _staticEnumerator.GetModules();

    //        return MergeModuleInfoArrays(m1, m2);
    //    }

    //    public ModuleInfo[] GetStartupLoadedModules()
    //    {
    //        ModuleInfo[] m1 = _directoryEnumerator.GetStartupLoadedModules();
    //        ModuleInfo[] m2 = _staticEnumerator.GetStartupLoadedModules();

    //        return MergeModuleInfoArrays(m1, m2);
    //    }

    //    public ModuleInfo GetModule(string moduleName)
    //    {
    //        ModuleInfo m1 = _staticEnumerator.GetModule(moduleName);

    //        return m1 ?? _directoryEnumerator.GetModule(moduleName);
    //    }

    //    private static ModuleInfo[] MergeModuleInfoArrays(
    //        ModuleInfo[] m1, ModuleInfo[] m2)
    //    {
    //        if (IsEmpty(m1))
    //            return m2;
    //        if (IsEmpty(m2))
    //            return m1;

    //        ModuleInfo[] m = new ModuleInfo[m1.Length + m2.Length];

    //        m1.CopyTo(m, 0);
    //        m2.CopyTo(m, m1.Length - 1);

    //        return m;
    //    }

    //    private static bool IsEmpty(ModuleInfo[] modules)
    //    {
    //        return (modules == null) || (modules.Length == 0);
    //    }
    //}
}