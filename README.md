# MGSharpMik

Module player example for MonoGame (based on SharpMik source code http://sharpmik.codeplex.com/)

Code: TheGouldfish & Dellis & FxGen


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

    //Load module from monogame content
    m_Mod = Content.Load<Module> ("Stardust");

    //Start playing...
    if (m_Mod!=null)
        m_Player.Play(m_Mod);

    m_Player.Play (m_Mod);


# Versions

V1.0
 - creation
V1.1
 - added monogame content importer
 

# License

MGSharpMik is released under Microsoft Public License (Ms-PL).
