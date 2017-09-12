# MGSharpMik

Module player example for MonoGame (based on SharpMik source code http://sharpmik.codeplex.com/)

Code: FxGen


# Usage

    MikMod m_Player;
    Module m_Mod = null;

    //Initialize player
    m_Player = new MikMod();
    try
    {
        m_Player.Init<XNADriver>("");
    }
    catch (System.Exception ex)
    {
        Debug.WriteLine(ex);
    }

    //Load Module
    m_Mod = m_Player.LoadModule("content\\stardust.MOD");

    //Start playing...
    if (m_Mod!=null)
        m_Player.Play(m_Mod);


# Versions

V1.0
 - creation

# License

MGSharpMik is released under Microsoft Public License (Ms-PL).
