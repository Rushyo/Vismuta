﻿using System;

namespace VismutaLib
{
    [Flags]
    public enum DeployMethodFlags : byte
    {
        None = 0
        , RunAfterDeploy = 1<<0
        , PsExec = 1<<1
        , Deflate = 1<<2
        , Inject = 1<<3
        , ObfuscateName = 1<<4
        , EncryptInteractive = 1<<5
        , EncryptNonInteractive = 1 << 6
        , ObfuscateVariables = 1<< 7
    }
}
