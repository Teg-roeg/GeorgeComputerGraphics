using UnityEngine;

public class OutCodeDriver : MonoBehaviour
{
    private void Start()
    {
        // 1. Test Constructor 1 (Vector2 point evaluation)
        Vector2 upPoint = new Vector2(0f, 2.0f); // 1000
        Vector2 downPoint = new Vector2(0f, -2.0f); // 0100
        Vector2 rightPoint = new Vector2(2.0f, 0f); // 0001
        Vector2 leftPoint = new Vector2(-2.0f, 0f); // 0010

        OutCode code1 = new OutCode(upPoint);
        OutCode code2 = new OutCode(downPoint);
        OutCode code3 = new OutCode(rightPoint);
        OutCode code4 = new OutCode(leftPoint);

        print("Up Point OutCode: " + code1.DisplayOutCode());
        print("Down Point OutCode: " + code2.DisplayOutCode());
        print("Right Point OutCode: " + code3.DisplayOutCode()); 
        print("Left Point OutCode: " + code4.DisplayOutCode());

        // 2. Test Constructor 2 (Explicit Booleans)
        OutCode codeBoolA = new OutCode(true, false, true, false);
        OutCode codeBoolB = new OutCode(true, false, false, true);  

        print("CodeBoolA: " + codeBoolA.DisplayOutCode());
        print("CodeBoolB: " + codeBoolB.DisplayOutCode());

        // 3. Test Operator Overloads
        OutCode duplicateCodeA = new OutCode(true, false, true, false);
        bool isEqual = (codeBoolA == duplicateCodeA);
        bool isNotEqual = (codeBoolA != codeBoolB);

        print("codeBoolA == duplicateCodeA? " + isEqual);
        print("codeBoolA != codeBoolB? " + isNotEqual);  

        // Logical AND (&)
        OutCode andResult = codeBoolA & codeBoolB;
        print("AND Result (codeBoolA & codeBoolB): " + andResult.DisplayOutCode());

        // Logical OR (|)
        OutCode orResult = codeBoolA | codeBoolB;
        print("OR Result (codeBoolA | codeBoolB): " + orResult.DisplayOutCode());
    }

}
