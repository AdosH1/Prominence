using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Prominence.Model;
using Prominence.Model.SaveModels;
using Prominence.Contexts;
using System.Linq;
using Prominence.Model.Interfaces;
using Utilities;
using Xamarin.Forms;

namespace Prominence.Controllers
{
    public static class SaveController
    {

        //TODO: Move these two static property classes into a different directory
        //Perhaps we consider making a Label generating class
        public static class ButtonLabelProperties
        {
            public static Color textColor = Color.Red;
            public static TextAlignment textAlignment = TextAlignment.Center;

        }

        public static class DialogueLabelProperties
        {
            public static Color textColor = Color.White;
            public static TextAlignment textAlignment = TextAlignment.Start;
        }
        public static void SavePlayer(PlayerModel thePlayerModelToSave)
        {
            string jsonStringToSave = Serialize<PlayerSaveModel>(CreatePlayerSaveModel(thePlayerModelToSave));
            AppPropertiesContext.Save(jsonStringToSave);
        }

        public static PlayerModel LoadPlayer()
        {
            if(IsPlayerStored())
            {
                PlayerSaveModel theSavedPlayer = Deserialize<PlayerSaveModel>(AppPropertiesContext.Load());

                return CreatePlayerModel(theSavedPlayer);
            }
            else
            {
                return new PlayerModel("Ados");
            }
        }

        public static bool IsPlayerStored()
        {
            return AppPropertiesContext.IsAvailable();
        }

        public static string Serialize<T>(T itemToSerialize)
        {
            return JsonSerializer.Serialize<T>(itemToSerialize);
        }    

        public static T Deserialize<T>(string stringToDeserialize)
        {
            return JsonSerializer.Deserialize<T>(stringToDeserialize);
        }

        public static PlayerModel CreatePlayerModel(PlayerSaveModel theSavedPlayer)
        {
            PlayerModel output = new PlayerModel(theSavedPlayer);
            output.Log = CreatePlayerModelLog(theSavedPlayer);

            return output;
        }

        public static PlayerSaveModel CreatePlayerSaveModel(PlayerModel thePlayerModel)
        {
            PlayerSaveModel output = new PlayerSaveModel(thePlayerModel);
            output.Log = CreatePlayerSaveModelLog(thePlayerModel);

            return output;
        }
        
        //TODO Create function to return a List<OurLabel>
        public static List<TypedLabel> CreatePlayerModelLog(PlayerSaveModel theSavedPlayer)
        {
            List<TypedLabel> output = new List<TypedLabel>();

            foreach(var savedLabel in theSavedPlayer.Log)
            {
                output.Append<TypedLabel>(CreateTypedLabel(savedLabel));
            }

            return output;
        }

        public static List<LabelSaveModel> CreatePlayerSaveModelLog(PlayerModel thePlayerModel)
        {
            List<LabelSaveModel> output = new List<LabelSaveModel>();
            foreach(var label in thePlayerModel.Log)
            {
                output.Append<LabelSaveModel>(CreateLabelSaveModel(label));
            }

            return output;
        }

        //TODO This method should use some external class to creat the TypedLabel
        //We should consider implementing some Factory for creating Labels. Currently it does
        //not create the colors, textalignment. I did not want to do weird logic in here.
        public static TypedLabel CreateTypedLabel(LabelSaveModel theLabelSaveModel)
        {
            TypedLabel output = new TypedLabel(type: theLabelSaveModel.Type);
            output.Text = theLabelSaveModel.Text;
            return output;
        }
        public static LabelSaveModel CreateLabelSaveModel(TypedLabel theLabel)
        {
            return new LabelSaveModel(theLabel);
        }

       
    }
}
