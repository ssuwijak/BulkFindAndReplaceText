namespace MyClasses
{
    public class FunctionReturn
    {
        public bool Flag { get; set; } = false;
        private string _text = string.Empty;
        public string Text
        {
            get => _text;
            set
            {
                _text = string.IsNullOrEmpty(value) ? "" : value.Trim();
                IsTextEmpty = _text == "";
            }
        }
        public bool IsTextEmpty { get; private set; }
        public FunctionReturn() { }
        public FunctionReturn(bool flag, string text) => SetValues(flag, text);
        public void SetValues(bool flag, string text)
        {
            Flag = flag;
            Text = text;
        }
        public void Reset() => SetValues(false, "");
        public void CheckNullOrEmptyWithTrim(string str)
        {
            Text = str;
            Flag = IsTextEmpty;
        }
    }
}
