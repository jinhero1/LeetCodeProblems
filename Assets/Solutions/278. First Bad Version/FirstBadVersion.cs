namespace FirstBadVersion
{
    public class Solution : VersionControl
    {
        private const int ONE = 1;
        private const int TWO = 2;

        public int FirstBadVersion(int n)
        {
            if (IsBadVersion(ONE))
            {
                return ONE;
            }

            int _goodVersion = ONE;
            int _badVersion = n;
            int _difference;
            int _checkedVersion;
            while (true)
            {
                _difference = _badVersion - _goodVersion;
                if (_difference <= ONE) break;

                _checkedVersion = _goodVersion + _difference / TWO;                
                if (IsBadVersion(_checkedVersion))
                {
                    _badVersion = _checkedVersion;
                }
                else
                {
                    _goodVersion = _checkedVersion;
                }
            }

            return _badVersion;
        }
    }
}