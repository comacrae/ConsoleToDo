namespace ConsoleToDoProject.Models;
using System.Collections.Generic;

public class Option
{
    public string FullName { get;}
    public string AbbreviatedName { get; }
    public string Description { get;}
    public string? DefaultValue { get;}
    public bool IsRequired { get;}
    public bool IsFlag {  get;}

    public bool FlagActive { get; set; }
    public string? Value { get; set; } = null;

    public Option(string abbreviatedName,string fullName, string description, string? defaultValue=null, bool isRequired=false, bool isFlag=false)
    {
        AbbreviatedName = abbreviatedName.ToLower()?? throw new ArgumentNullException("Abbreivated Name cannot be null");;
        FullName = fullName.ToLower()?? throw new ArgumentNullException("Full Name cannot be null");;
        Description = description?? throw new ArgumentNullException("Description cannot be null");
        if(isRequired )
        {
            if(defaultValue != null)
                throw new TypeInitializationException("Option", new ArgumentException("defaultValue must be null if option isRequired"));
            else if (IsFlag)
            {
                throw new TypeInitializationException("Option", new ArgumentException("An option that is a flag cannot also be required"));
            }
        }else if(!isRequired && defaultValue == null)
        {
            throw new TypeInitializationException("Option", new ArgumentNullException("defaultValue cannot be null if option is not required"));
        }else // not required and default value is set to something
        {
            DefaultValue = defaultValue;
            Value = defaultValue;
        }
        IsRequired = isRequired;
        IsFlag = isFlag;
        if (isFlag) 
        { 
            if(DefaultValue != "true" && DefaultValue != "false")
                throw new TypeInitializationException("Option", new ArgumentNullException("A Flag Option must have a default value equal to 'true' or 'false'"));
            FlagActive = DefaultValue == "true";
        }
    }

    public void SetValue(string? value)
    {
        if (IsFlag)
        {
            throw new ArgumentException("Option is a flag; Must be set using FlagActive setter");
        }

        if(value == null)
        {
            if (DefaultValue == null)
            {
                throw new ArgumentNullException("Value is required and cannot be null");
            }

            value = DefaultValue;
        }

        Value = value;
    }


}
