using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DCTL;

public class PoleDirectionInstance
{
    public static int[,,] PoleLineDir = {
        { {0, 1}, {0, 1}, {0, 1}, {0, 1}, {0, 1}, {0, 1}, {0, 1}, {1, 1},               },
        { {270, 1}, {1, 1}, {0, 1}, {270, 1}, {1, 1}, {270, 1}, {0, 1}, {1, 1},           },
        { {270, 1}, {270, 1}, {180, 1}, {1, 1}, {270, 1}, {270, 1}, {180, 1}, {270, 1},   },
        { {270, 1}, {270, 1}, {1, 1 }, {270, 0}, {270, 1}, {0, 1}, {0, 1}, {270, 1},      },
        { {270, 1}, {270, 1}, {270, 1}, {180, 1}, {1, 1}, {0, 1}, {90, 1}, {270, 1},      },
        { {270, 1}, {270, 1}, {1, 1}, {270, 1 }, {180, 270}, {270, 1}, {1, 1}, {270, 1},  },
        { {270, 1}, {270, 0}, {270, 0}, {1, 0}, {1, 0}, {270, 0}, {1, 1}, {270, 1},   },
        { {0, 1}, {0, 1}, {0, 1}, {270, 0}, {0, 1}, {0, 1}, {0, 1}, {270, 1}              }
    };

    public static ELineDir GetDir(int vertical, int horizontal, int lineNum)
    {

        return (ELineDir)PoleLineDir[vertical, horizontal, lineNum];
    }
}

