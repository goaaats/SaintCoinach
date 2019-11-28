﻿using Microsoft.EntityFrameworkCore;

namespace SaintCoinach.Libra
{
    using System;

    public partial class Entities : DbContext
    {
        public Entities(string connectionString)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<AchievementCategory> AchievementCategories { get; set; }
        public virtual DbSet<AchievementKind> AchievementKinds { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<BaseParam> BaseParams { get; set; }
        public virtual DbSet<BeastTribe> BeastTribes { get; set; }
        public virtual DbSet<BNpcName> BNpcNames { get; set; }
        public virtual DbSet<BNpcName_PlaceName> BNpcName_PlaceName { get; set; }
        public virtual DbSet<ClassJob> ClassJobs { get; set; }
        public virtual DbSet<ClassJob_ClassJobCategory> ClassJob_ClassJobCategory { get; set; }
        public virtual DbSet<ClassJobCategory> ClassJobCategories { get; set; }
        public virtual DbSet<Colosseum> Colosseums { get; set; }
        public virtual DbSet<ContentRoulette> ContentRoulettes { get; set; }
        public virtual DbSet<ContentType> ContentTypes { get; set; }
        public virtual DbSet<CraftType> CraftTypes { get; set; }
        public virtual DbSet<Emote> Emotes { get; set; }
        public virtual DbSet<ENpcResident> ENpcResidents { get; set; }
        public virtual DbSet<ENpcResident_PlaceName> ENpcResident_PlaceName { get; set; }
        public virtual DbSet<ENpcResident_Quest> ENpcResident_Quest { get; set; }
        public virtual DbSet<FCHierarchy> FCHierarchies { get; set; }
        public virtual DbSet<FCRank> FCRanks { get; set; }
        public virtual DbSet<FCReputation> FCReputations { get; set; }
        public virtual DbSet<Frontline01> Frontline01 { get; set; }
        public virtual DbSet<Gathering> Gatherings { get; set; }
        public virtual DbSet<GatheringType> GatheringTypes { get; set; }
        public virtual DbSet<GCRankGridaniaFemaleText> GCRankGridaniaFemaleTexts { get; set; }
        public virtual DbSet<GCRankGridaniaMaleText> GCRankGridaniaMaleTexts { get; set; }
        public virtual DbSet<GCRankLimsaFemaleText> GCRankLimsaFemaleTexts { get; set; }
        public virtual DbSet<GCRankLimsaMaleText> GCRankLimsaMaleTexts { get; set; }
        public virtual DbSet<GCRankUldahFemaleText> GCRankUldahFemaleTexts { get; set; }
        public virtual DbSet<GCRankUldahMaleText> GCRankUldahMaleTexts { get; set; }
        public virtual DbSet<GeneralAction> GeneralActions { get; set; }
        public virtual DbSet<GrandCompany> GrandCompanies { get; set; }
        public virtual DbSet<GuardianDeity> GuardianDeities { get; set; }
        public virtual DbSet<GuildOrder> GuildOrders { get; set; }
        public virtual DbSet<InstanceContent> InstanceContents { get; set; }
        public virtual DbSet<InstanceContentType> InstanceContentTypes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Item_ClassJob> Item_ClassJob { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemSery> ItemSeries { get; set; }
        public virtual DbSet<ItemSpecialBonu> ItemSpecialBonus { get; set; }
        public virtual DbSet<ItemUICategory> ItemUICategories { get; set; }
        public virtual DbSet<ItemUIKind> ItemUIKinds { get; set; }
        public virtual DbSet<JournalCategory> JournalCategories { get; set; }
        public virtual DbSet<JournalGenre> JournalGenres { get; set; }
        public virtual DbSet<LodestoneSystemDefine> LodestoneSystemDefines { get; set; }
        public virtual DbSet<NotebookDivision> NotebookDivisions { get; set; }
        public virtual DbSet<PlaceName> PlaceNames { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<Quest_ClassJob> Quest_ClassJob { get; set; }
        public virtual DbSet<QuestWebEx> QuestWebExes { get; set; }
        public virtual DbSet<QuestWebType> QuestWebTypes { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeElement> RecipeElements { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Tomestone> Tomestones { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
    }
}
