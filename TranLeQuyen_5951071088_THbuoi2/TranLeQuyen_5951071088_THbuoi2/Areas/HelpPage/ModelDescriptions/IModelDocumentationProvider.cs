using System;
using System.Reflection;

namespace TranLeQuyen_5951071088_THbuoi2.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}