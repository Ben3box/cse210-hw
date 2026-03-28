using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private string _originalText;

    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _originalText = text;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public Reference GetReference() => _reference;
    public string GetOriginalText() => _originalText;
    public bool IsRange() => _reference.IsRange();

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden() => _words.All(w => w.IsHidden());

    public int GetHiddenPercentage()
    {
        int hidden = _words.Count(w => w.IsHidden());
        return _words.Count == 0 ? 0 : (hidden * 100) / _words.Count;
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {text}";
    }
}