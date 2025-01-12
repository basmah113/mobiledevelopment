// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded.HapticFeedback
{

    public class HapticFeedbackController : MonoBehaviour
    {

        public void LightFeedback()
        {
            HapticFeedback.HeavyFeedback();
        }

        public void MediumFeedback()
        {
            Handheld.Vibrate();
            //HapticFeedback.MediumFeedback();
        }

        public void HeavyFeedback()
        {
            Handheld.Vibrate();
            //HapticFeedback.HeavyFeedback();
        }

    }

}
