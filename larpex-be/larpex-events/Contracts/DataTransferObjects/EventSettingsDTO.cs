﻿namespace larpex_events.Contracts.DataTransferObjects;

public class EventSettingsDTO
{
    public int? MaxPlayerLimit { get; set; }
    public bool? IsVisible { get; set; }
    public bool? IsExternalOrganiser { get; set; }
}
