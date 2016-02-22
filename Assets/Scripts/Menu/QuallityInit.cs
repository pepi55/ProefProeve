using UnityEngine;
using System.Collections;

public class QuallityInit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        OptionSaveData data = new OptionSaveData();
        try
        {
            Util.Serialization.Load("OptionData", Util.Serialization.fileTypes.binary, ref data);

            if (data == null)
            {
                data = new OptionSaveData();
                Util.Serialization.Save("OptionData", Util.Serialization.fileTypes.binary, data);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            Debug.Log(data);
            Util.Debugger.Log("Expetion loading data", e.Message);
        }

        try
        {
            QualitySettings.vSyncCount = data.Vsync ? 1 : 0;
            QualitySettings.masterTextureLimit = data.TextureResolution;

            switch (data.AALevel)
            {
                case 0:
                    QualitySettings.antiAliasing = 0;
                    break;

                case 1:
                    QualitySettings.antiAliasing = 2;
                    break;

                case 2:
                    QualitySettings.antiAliasing = 4;
                    break;

                case 3:
                    QualitySettings.antiAliasing = 8;
                    break;
            }

            if (data.ResolutionIndex != -1 && data.screenHeight != -1 && data.screenWidth != -1)
            {
                if (!Application.isEditor)
                    Screen.SetResolution(data.screenWidth, data.screenHeight, data.useFullScreen);
            }
        }
        catch (System.Exception e)
        {
            Util.Debugger.Log("Exeption Assigning data", e);//.Message + "/n" + e.Source + "/n" + e.StackTrace);
            Util.Debugger.Log("Exception Assinging Data Value", data);
        }

        Destroy(this);
    }

   
}
