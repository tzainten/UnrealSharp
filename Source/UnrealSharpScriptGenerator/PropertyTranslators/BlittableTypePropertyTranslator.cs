﻿using System;
using System.Text;
using EpicGames.UHT.Types;

namespace UnrealSharpScriptGenerator.PropertyTranslators;

public class BlittableTypePropertyTranslator : SimpleTypePropertyTranslator
{
    public BlittableTypePropertyTranslator(Type propertyType, string managedType) : base(propertyType, managedType)
    {
    }

    public override string GetMarshaller(UhtProperty property)
    {
        return $"BlittableMarshaller<{GetManagedType(property)}>";
    }

    public override void ExportCppDefaultParameterAsLocalVariable(GeneratorStringBuilder builder, string variableName, string defaultValue,
        UhtFunction function, UhtProperty paramProperty)
    {
        if (defaultValue == "None")
        {
            builder.AppendLine($"Name {variableName} = Name.None;");
        }
        else
        {
            builder.AppendLine($"Name {variableName} = Name(\"{defaultValue}\");");
        }
    }
}