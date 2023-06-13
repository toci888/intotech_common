﻿namespace Intotech.Common.Bll.Interfaces.ChorDtoBll;

public interface IDtoLogicManager<TDto>
{
    void AddDtoLogic(IDtoEntityHandler<TDto> logic);

    TDto RunGet();
    TDto RunSet();
}