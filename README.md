# LogarSolutions.Extensions

Simple and very helpful extension methods used in every solution. Both for .NET Framework 4.5 and .NET Standard 1.4
Available also as NuGet package.

# Enumerable extensions

**IsEmpty**
Checks if IEnumerable is null or has no elements.

**AddIfNotNull**
Add item to list if item is not null.

**DistinctBy**
Distinct by property specified.

**Batch**
Create multiple enumerable batches with max elements.

# Object extensions

**NullCheck**
Throw exception if null.

**IsNullOrDefault**
Is null or default value.


# String extensions

**IsNullOrEmpty**
Check if string is null or empty.

**IsNullOrWhiteSpace**
Check if string is null or whitespace.

**IsAllUpper**
Check if given string has all upper characters.

**FirstLetterToUpper**
Change input string that first character is capitalize.

**SafeToUpper**
Safe to upper case. Empty string if input is null.

**SafeToLower**
Safe to lower case. Empty string if input is null.

**ToSafeString**
ToString representation of an object; Empty string if object is null or in case of exception.

**SafeTrim**
Trim string if string is not empty otherwise return empty string.

**SafeSubstring**
Get safe substring of a string or empty string.

**ToSafeLong**
Parse string to long. Default return value if parse fails.

**Contains**
String contains extension method with ignore case possibility.

**ConcatValues**
Concatenate values with given separator.

**AfterCharSubstring**
Get substring after first occurrence of input character.
