namespace ConsoleToDoProject.Models;
using System.Collections.Generic;

public class Option
{
    public string Name { get;}
    public string Description { get;}
    public string? DefaultValue { get;}
    public string? Value { set; get; }
    public bool IsRequired { get;}
    public bool IsFlag {  get;}
    public bool AllowMultiple { get;}

    public Option(string name, string description, string? defaultValue=null, bool isRequired=false, bool isFlag=false, bool allowMultiple = false)
    {
        Name = name?? throw new ArgumentNullException("Name cannot be null");;
        Description = description?? throw new ArgumentNullException("Description cannot be null");
        DefaultValue = defaultValue;
        IsRequired = isRequired;
        IsFlag = isFlag;
        AllowMultiple = allowMultiple;
        

        if (IsFlag && AllowMultiple)
            throw new ArgumentException($"{nameof(IsFlag)} and {nameof(AllowMultiple)} cannot both be true in Options constructor");
    }

    public void SetValue(string? value)
    {
        if (IsFlag)
        {
            throw new ArgumentException("No input value allowed; Option is a flag"); 
        }
        if(value == null)
        {
            Value = DefaultValue ?? throw new ArgumentNullException("Default Value is null; Input required");
        }
        else
        {
            Value= value;
        }
    }


}
