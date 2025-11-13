using System;
using System.Collections.Generic;

[Serializable]
public class GenePair
{
    public string DominantId;
    public string RecessiveId;

    public GenePair()
    {
        DominantId = "";
        RecessiveId = "";
    }
}

[Serializable]
public class GenesContainer
{
    public GenePair Body;
    public GenePair Arm;
    public GenePair Feet;
    public GenePair Pattern;
    public GenePair Eye;
    public GenePair Mouth;
    public GenePair Ear;
    public GenePair Acc;
    public GenePair Blush;
    public GenePair Wing;

    public GenePair Color;
    public GenePair Personality;
    public PartColorGenes PartColors;

    public GenesContainer()
    {
        Body = new GenePair();
        Arm = new GenePair();
        Feet = new GenePair();
        Pattern = new GenePair();
        Eye = new GenePair();
        Mouth = new GenePair();
        Ear = new GenePair();
        Acc = new GenePair();
        Wing = new GenePair();
        Blush = new GenePair();

        Color = new GenePair();
        Personality = new GenePair();
        PartColors = new PartColorGenes();
    }
}

[Serializable]
public class PartColorGenes
{
    public string BodyColorId;
    public string ArmColorId;
    public string FeetColorId;
    public string PatternColorId;
    public string EarColorId;
    public string BlushColorId;

    public PartColorGenes()
    {
        BodyColorId = "";
        ArmColorId = "";
        FeetColorId = "";
        PatternColorId = "";
        EarColorId = "";
        BlushColorId = "";
    }
}

[Serializable]
public class PetSaveData
{
    public bool IsLeft;
    public bool IsSick;

    public bool IsInfoUnlocked;
    public string ID;
    public string Name;
    public string FatherId;
    public string MotherId;
    public GenesContainer Genes;
    public string GrowthStage;
    public float Hunger;
    public float Happiness;
    public float Energy;
    public float Cleanliness;
    public float Health;
 

    public PetSaveData()
    {
        IsLeft = false;
        IsSick = false;

        IsInfoUnlocked = false;
        ID = "";
        Name = "";
        FatherId = "";
        MotherId = "";
        Genes = new GenesContainer();
        GrowthStage = "Egg";
        Hunger = 100f;
        Happiness = 100f;
        Energy = 100f;
        Cleanliness = 100f;
        Health = 100f;
    }
}

[Serializable]
public class IslandData
{
    public bool IsOpen;
    public bool IsLeft;
    public bool IsMarried;
    public PetSaveData IslandPetSaveData;
    public float Affinity;

    public IslandData()
    {
        IsOpen = false;
        IsLeft = false;
        IsMarried = false;
        IslandPetSaveData = new PetSaveData();
        Affinity = 50f;
    }
}

[Serializable]
public class UserItemData
{
    public int IslandTicket;
    public int MissingPoster;
    public int Item3Amount;
    public int Item4Amount;
    public int Item5Amount;

    public UserItemData()
    {
        IslandTicket = 1;
        MissingPoster = 1;
        Item3Amount = 0;
        Item4Amount = 0;
        Item5Amount = 0;
    }

}

[Serializable]
public class UserData
{
    public string UID;
    public Language CurLanguage;
    public string UserName;
    public int MaxPetAmount;
    public List<PetSaveData> HavePetList;
    public List<PetRecordData> HadPetList;
    public List<IslandPetRecordData> IslandPetList;
    public IslandData Island;
    public UserItemData Items;

    public UserData()
    {
        UID = "";
        CurLanguage = Language.ENG;
        UserName = "";
        MaxPetAmount = 1;
        HavePetList = new List<PetSaveData>();
        HadPetList = new List<PetRecordData>();
        Island = new IslandData();
        IslandPetList = new List<IslandPetRecordData>();
        Items = new UserItemData();
    }
}
    public class PetRecordData
    {
        public string PetId;
        public string DisplayName;
        public GenesContainer Genes;

        public PetRecordData(PetSaveData source)
        {
            PetId = source.ID;
            DisplayName = source.Name;
            Genes = source.Genes;
        }
    }
public class IslandPetRecordData
{
    public GenesContainer Genes;

    public IslandPetRecordData()
    {
        Genes = new GenesContainer();
    }

    public IslandPetRecordData(PetSaveData source)
    {
        Genes = source.Genes;
    }
}
