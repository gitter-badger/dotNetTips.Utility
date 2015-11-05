' ***********************************************************************
' Assembly         : dotNetTips.Utility.Portable
' Author           : David McCarter
' Created          : 12-04-2013
'
' Last Modified By : David McCarter
' Last Modified On : 05-12-2014
' ***********************************************************************
' <copyright file="StringHelper.vb" company="David McCarter Consulting">
'     David McCarter Consulting. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Text.RegularExpressions

''' <summary>
''' Text helper class.
''' </summary>
''' <remarks></remarks>
Public Module StringHelper

    ''' <summary>
    ''' Fixes string for input into SQL.
    ''' </summary>
    ''' <param name="input">Text to fix.</param>
    ''' <returns>Fixed string.</returns>
    ''' <remarks>Replaces single quote with double quote.</remarks>
    Public Function SqlEncode(ByVal input As String) As String

        If String.IsNullOrEmpty(input) Then
            Return String.Empty
        End If

        Return PrintableOnly(input).Replace(ControlChars.SingleQuote, ControlChars.DoubleQuote)

    End Function

    ''' <summary>
    ''' Removes unprintable characters.
    ''' </summary>
    ''' <param name="input">The input string.</param>
    ''' <returns></returns>
    Public Function PrintableOnly(ByVal input As String) As String

        If String.IsNullOrEmpty(input) Then
            Return String.Empty
        Else
            'Return only characters in the range from space to tilde, plus tab and cr/lf
            Return New Regex("[^ -~" & vbTab & vbCr & vbLf & "]").Replace(input, String.Empty)
        End If

    End Function

    ''' <summary>
    ''' Correctly compares two strings.
    ''' </summary>
    ''' <param name="original">First string to compare.</param>
    ''' <param name="compareTo">Second string to compare.</param>
    ''' <returns>True if strings are the same.</returns>
    ''' <remarks></remarks>
    Public Function Compare(ByVal original As String, ByVal compareTo As String) As Boolean
        Contract.Requires(Of ArgumentNullException)(String.IsNullOrEmpty(original) = False)
        Contract.Requires(Of ArgumentNullException)(String.IsNullOrEmpty(compareTo) = False)

        If original.Length <> compareTo.Length Then
            Return False
        End If

        Return If(String.CompareOrdinal(original, compareTo) >= 0, True, False)

    End Function

    ''' <summary>
    ''' Creates a Guid
    ''' </summary>
    ''' <returns>Guid as text</returns>
    ''' <remarks></remarks>
    Public Function CreateGuid() As String

        Return Guid.NewGuid.ToString

    End Function

    ''' <summary>
    ''' Spaces the specified number.
    ''' </summary>
    ''' <param name="number">The number.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Space(ByVal number As Integer) As String
        Contract.Requires(Of ArgumentNullException)(number >= 0)

        Return New String(" "c, number)

    End Function

    ''' <summary>
    ''' Removes the spaces.
    ''' </summary>
    ''' <param name="input">The input.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveSpaces(input As String) As String
        Contract.Requires(Of ArgumentNullException)(input IsNot Nothing)

        Return input.Replace(" "c, String.Empty)

    End Function

    ''' <summary>
    ''' Removes the character.
    ''' </summary>
    ''' <param name="input">The input.</param>
    ''' <param name="character">The character.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveCharacter(input As String, character As Char) As String
        Contract.Requires(Of ArgumentNullException)(input IsNot Nothing)
        Contract.Requires(Of ArgumentNullException)(String.IsNullOrWhiteSpace(character.ToString) = False)

        Return input.Replace(character, String.Empty)

    End Function

End Module