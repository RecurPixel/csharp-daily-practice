// * Create interfaces `IPlayable` and `IRecordable` with methods `Play()` and `Record()`.
// * Create a class `MediaPlayer` that implements both.
// * Demonstrate calling both interface methods through their references.

// 📝 *Bonus:* Add another class `AudioRecorder` that implements only `IRecordable` and show polymorphic behavior.



interface IPlayable
{
    void Play();
}

interface IRecordable
{
    void Record();
}

class MediaPlayer : IPlayable, IRecordable
{
    public void Play()
    {
        Console.WriteLine("Now Playing");
    }
    public void Record()
    {
        Console.WriteLine("Now Recording in Media Player");
    }

}

class AudioRecorder : IRecordable
{
    public void Record()
    {
        Console.WriteLine("Now Recording");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        IRecordable[] ir = new IRecordable[5];

        for(int i = 0; i < 5; i++)
        {
            if(i % 2 == 0)
            {
            ir[i] = new MediaPlayer();
            }
            else
            {
                ir[i] = new AudioRecorder();
            }
        }

        foreach(IRecordable ar in ir)
        {
            ar.Record();
        }
    }
}