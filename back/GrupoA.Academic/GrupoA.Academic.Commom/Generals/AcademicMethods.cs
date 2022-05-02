using GrupoA.Academic.Commom.Extensions;
using System;
using System.Text.RegularExpressions;

namespace GrupoA.Academic.Commom.Generals;

public static class AcademicMethods
{
    private static readonly string OnlyNumberRegex = "[^0-9]";
    private static readonly string EmailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

    public static DateTime Now()    
        => DateTime.UtcNow.SetKind();

    public static string ExtractNumbersOnly(string value)
        => (!string.IsNullOrEmpty(value)) ? Regex.Replace(value, OnlyNumberRegex, "") : value;

    public static bool EmailValidator(string value)
        => Regex.IsMatch(value, EmailRegex);
    public static bool CpfValidator(string value)
    {
        if (string.IsNullOrEmpty(value)) 
            return false;

        int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                              
        value = ExtractNumbersOnly(value);        
        if (value.Length != 11)
            return false;

        var cpf = value[..9];
        var total = 0;

        for (int i = 0; i < 9; i++)
            total += int.Parse(cpf[i].ToString()) * multiplier1[i];

        var remainder = (total % 11 < 2) ? 0 : 11 - (total % 11);

        var digit = remainder.ToString();
        cpf += digit;
        total = 0;
        for (int i = 0; i < 10; i++)
            total += int.Parse(cpf[i].ToString()) * multiplier2[i];

        remainder = (total % 11 < 2) ? 0 : 11 - (total % 11);

        digit += remainder;
        return value.EndsWith(digit);
    }

    public static bool Filled(string value)    
        => !string.IsNullOrEmpty(value);

    public static bool Filled(int value)
        => value > 0;

    public static bool Filled(Guid? value)    
        => !string.IsNullOrEmpty(value?.ToString());
    
    public static bool Filled(Guid value)    
        => !string.IsNullOrEmpty(value.ToString());    
}