namespace FirstBadVersion
{
    public class VersionControl
    {
        private int badVersion;

        public void CommitBadVersion(int version)
        {
            badVersion = version;
        }

        protected bool IsBadVersion(int version)
        {
            return version >= badVersion;
        }
    }
}