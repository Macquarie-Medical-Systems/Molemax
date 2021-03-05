using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Molemax.Models.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ABCD",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mikroId = table.Column<int>(nullable: false),
                    assymetry = table.Column<int>(nullable: false),
                    segments = table.Column<int>(nullable: false),
                    color = table.Column<int>(nullable: false),
                    structural_components = table.Column<int>(nullable: false),
                    change_nevus = table.Column<int>(nullable: true),
                    abcd_score = table.Column<float>(nullable: false),
                    abcd_e_score = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABCD", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ActionLog",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    performed_action = table.Column<int>(nullable: false),
                    ts = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    object_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ChangedLoc",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosNr = table.Column<int>(nullable: false),
                    LocText = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangedLoc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Complexion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complexion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DDSys",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    host = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    hostver = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    dbver = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Reserved1 = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Reserved2 = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Reserved3 = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Reserved4 = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Reserved5 = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDSys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEFBodymapPosition",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body_pos_id = table.Column<int>(nullable: true),
                    position_text = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    location_text = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    dummy_position = table.Column<int>(nullable: true),
                    X1 = table.Column<int>(nullable: true),
                    Y1 = table.Column<int>(nullable: true),
                    X2 = table.Column<int>(nullable: true),
                    Y2 = table.Column<int>(nullable: true),
                    body_type = table.Column<byte>(nullable: true),
                    bar_location_text = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    light_intensity_text = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    other_instruction_text = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    remark_text = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    hint_text = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFBodymapPosition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFDiagnoses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origin_id = table.Column<int>(nullable: false),
                    shortname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    fullname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    risk = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    favorite = table.Column<int>(nullable: true),
                    category = table.Column<int>(nullable: true),
                    parent_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFDiagnoses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFKen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bmp = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFKen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFLocalTxt",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxtPos = table.Column<int>(nullable: true),
                    TxtLokal = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFLocalTxt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFMakroKen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bmp = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFMakroKen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFMakroLokal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosMann = table.Column<byte>(nullable: true),
                    TxtMann = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TxtLokal = table.Column<int>(nullable: true),
                    r = table.Column<byte>(nullable: true),
                    g = table.Column<byte>(nullable: true),
                    b = table.Column<byte>(nullable: true),
                    Hotspot = table.Column<byte>(nullable: true),
                    Jumppos = table.Column<byte>(nullable: true),
                    Area = table.Column<byte>(nullable: true),
                    PosX1 = table.Column<int>(nullable: true),
                    PosY1 = table.Column<int>(nullable: true),
                    PosX2 = table.Column<int>(nullable: true),
                    PosY2 = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFMakroLokal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFMikroKen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bmp = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFMikroKen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFMikroLokal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosMann = table.Column<byte>(nullable: true),
                    TxtMann = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TxtLokal = table.Column<int>(nullable: true),
                    r = table.Column<byte>(nullable: true),
                    g = table.Column<byte>(nullable: true),
                    b = table.Column<byte>(nullable: true),
                    Hotspot = table.Column<byte>(nullable: true),
                    Jumppos = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFMikroLokal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFPublicDBFields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tableid = table.Column<int>(nullable: false),
                    groupid = table.Column<int>(nullable: true),
                    field = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    represented = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    representedid = table.Column<int>(nullable: true),
                    data = table.Column<int>(nullable: false),
                    valuelist = table.Column<bool>(nullable: false),
                    existance = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFPublicDBFields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFPublicDBItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    object_name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    obj_identifier = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    tbl = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    represented_string = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    represented_name = table.Column<int>(nullable: true),
                    is_table = table.Column<bool>(nullable: false),
                    data_format = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFPublicDBItems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFPublicDBTables",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    table = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    represented = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    existance = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFPublicDBTables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFSelectKen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bmp = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFSelectKen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFSmallKen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bmp = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFSmallKen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEFSys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    prefix = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    codepage = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    version = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    compatibility = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFSys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagsourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Diagsource",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origin_id = table.Column<int>(nullable: false),
                    shortname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    fullname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    risk = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    favorite = table.Column<int>(nullable: true),
                    category = table.Column<int>(nullable: true),
                    parent_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagsource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicgroup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicgroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExpertizerABCD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<int>(nullable: true),
                    ImageID = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    A_Score = table.Column<int>(nullable: true),
                    B_Score = table.Column<int>(nullable: true),
                    C_Score = table.Column<int>(nullable: true),
                    D_Score = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertizerABCD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExpertizerMain",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<int>(nullable: true),
                    MainDX = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    SubDX = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageID = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertizerMain", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExpertizerS7",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<int>(nullable: true),
                    ImageID = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    S1 = table.Column<int>(nullable: true),
                    S2 = table.Column<int>(nullable: true),
                    S3 = table.Column<int>(nullable: true),
                    S4 = table.Column<int>(nullable: true),
                    S5 = table.Column<int>(nullable: true),
                    S6 = table.Column<int>(nullable: true),
                    S7 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertizerS7", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExpertizerSelf",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<int>(nullable: true),
                    ImageID = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Diag_Class = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertizerSelf", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EyeColor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeColor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HairColor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairColor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mikroId = table.Column<int>(nullable: false),
                    version = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    symmetry = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    color = table.Column<int>(nullable: true),
                    diameter = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    area = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    score = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    makroId = table.Column<int>(nullable: false),
                    fupId = table.Column<int>(nullable: false),
                    version = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    sensitivity = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    naevi_good = table.Column<int>(nullable: false),
                    naevi_middle = table.Column<int>(nullable: false),
                    naevi_bad = table.Column<int>(nullable: false),
                    preceding_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Memc",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    closeupId = table.Column<int>(nullable: false),
                    fupId = table.Column<int>(nullable: false),
                    version = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    sensitivity = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    naevi_good = table.Column<int>(nullable: false),
                    naevi_middle = table.Column<int>(nullable: false),
                    naevi_bad = table.Column<int>(nullable: false),
                    preceding_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    birthdate = table.Column<DateTime>(nullable: false),
                    sex = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    insnr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    insnr_usa = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    insident = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    sender = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    bdtpat_id = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    family = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    fup_date = table.Column<DateTime>(nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    zip = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    phone_h = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    phone_w = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    phone_c = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    e_mail = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    sending = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    senddate = table.Column<DateTime>(nullable: true),
                    DestFTPID = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    recipient = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    image_path = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    risk = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    waiting_room = table.Column<bool>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    tsId = table.Column<int>(nullable: false),
                    ca_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    barcode = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    barcode_type = table.Column<int>(nullable: true),
                    ethnicgroup = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    eyecolor = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    haircolor = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    skincolor = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    complexion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    kis = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    dicom = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    patheight = table.Column<int>(nullable: true),
                    atbmheight = table.Column<int>(nullable: true),
                    pms_patient_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "S7p",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mikroId = table.Column<int>(nullable: false),
                    atypical_pigment_network = table.Column<int>(nullable: false),
                    gray_blue_areas = table.Column<int>(nullable: false),
                    atypical_vascular_pattern = table.Column<int>(nullable: false),
                    streaks = table.Column<int>(nullable: false),
                    blotches = table.Column<int>(nullable: false),
                    dots_globules = table.Column<int>(nullable: false),
                    regression_pattern = table.Column<int>(nullable: false),
                    score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S7p", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sender",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SkinColor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinColor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Timestamps",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(nullable: true),
                    date_last_accessed = table.Column<DateTime>(nullable: true),
                    pcname = table.Column<string>(type: "nvarchar(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timestamps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    pwd = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    myrights = table.Column<short>(nullable: false),
                    rights = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    tsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Aisinfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(nullable: false),
                    family = table.Column<int>(nullable: true),
                    personal = table.Column<int>(nullable: true),
                    nevus = table.Column<int>(nullable: true),
                    uv = table.Column<int>(nullable: true),
                    skin = table.Column<int>(nullable: true),
                    dns = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aisinfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Aisinfo_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bodymaps",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(nullable: false),
                    bms_type = table.Column<int>(nullable: false),
                    tsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodymaps", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bodymaps_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cosmetic",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(nullable: false),
                    related_id = table.Column<int>(nullable: false),
                    treatment_id = table.Column<int>(nullable: false),
                    imgname = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    effectval = table.Column<int>(nullable: true),
                    deflabel = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    defpath = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    drivetype = table.Column<int>(nullable: true),
                    tsId = table.Column<int>(nullable: false),
                    crc = table.Column<int>(nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosmetic", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cosmetic_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpressImage",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(nullable: false),
                    imgname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    attention = table.Column<bool>(nullable: false),
                    origin = table.Column<int>(nullable: true),
                    score_abcd = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    score_s7p = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    score_memi = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    score_mema = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    score_tricho = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    reserved1 = table.Column<bool>(nullable: false),
                    reserved2 = table.Column<bool>(nullable: false),
                    reserved3 = table.Column<bool>(nullable: false),
                    reserved4 = table.Column<bool>(nullable: false),
                    zoom = table.Column<double>(nullable: true),
                    camname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    camsets = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpressImage", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExpressImage_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(nullable: false),
                    mikroId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    examinator = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    diagnoseId = table.Column<int>(nullable: true),
                    histo_nr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    clark = table.Column<int>(nullable: true),
                    breslow = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deflabel = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    defpath = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    drivetype = table.Column<int>(nullable: true),
                    tsId = table.Column<int>(nullable: false),
                    crc = table.Column<int>(nullable: true),
                    pat_diagnose = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    report = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diagdate = table.Column<DateTime>(nullable: true),
                    imgname = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Histos_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(nullable: false),
                    kind = table.Column<int>(nullable: false),
                    origin = table.Column<int>(nullable: false),
                    kenpos = table.Column<int>(nullable: false),
                    loctext = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgname = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    deflabel = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    defpath = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    drivetype = table.Column<int>(nullable: true),
                    userId = table.Column<int>(nullable: false),
                    sender_id = table.Column<int>(nullable: true),
                    tsId = table.Column<int>(nullable: false),
                    treatment = table.Column<DateTime>(nullable: true),
                    crc = table.Column<int>(nullable: true),
                    dermanet = table.Column<bool>(nullable: false),
                    scoption = table.Column<int>(nullable: true),
                    scdate = table.Column<double>(nullable: true),
                    attention = table.Column<bool>(nullable: false),
                    irisk = table.Column<int>(nullable: true),
                    newloc = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK_Images_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsHisto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    histoId = table.Column<int>(nullable: false),
                    docname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsHisto", x => x.id);
                    table.ForeignKey(
                        name: "FK_DocumentsHisto_Histos_histoId",
                        column: x => x.histoId,
                        principalTable: "Histos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camset",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(nullable: false),
                    quality = table.Column<int>(nullable: true),
                    strobe = table.Column<int>(nullable: true),
                    exposure_mode = table.Column<int>(nullable: true),
                    image_mode = table.Column<int>(nullable: true),
                    white_balance = table.Column<int>(nullable: true),
                    contrast = table.Column<int>(nullable: true),
                    color_gain = table.Column<int>(nullable: true),
                    sharpness = table.Column<int>(nullable: true),
                    iso = table.Column<int>(nullable: true),
                    av = table.Column<int>(nullable: true),
                    tv = table.Column<int>(nullable: true),
                    exposure_comp = table.Column<int>(nullable: true),
                    zoompos = table.Column<int>(nullable: true),
                    camera = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    reserved1 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    reserved2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    reserved3 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    reserved4 = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camset", x => x.id);
                    table.ForeignKey(
                        name: "FK_Camset_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Closeup",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(nullable: false),
                    makroId = table.Column<int>(nullable: false),
                    X1 = table.Column<int>(nullable: false),
                    Y1 = table.Column<int>(nullable: false),
                    X2 = table.Column<int>(nullable: false),
                    Y2 = table.Column<int>(nullable: false),
                    fupId = table.Column<int>(nullable: true),
                    bmpos = table.Column<int>(nullable: true),
                    bms_id = table.Column<int>(nullable: true),
                    oldparent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Closeup", x => x.id);
                    table.ForeignKey(
                        name: "FK_Closeup_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(nullable: false),
                    docname = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.id);
                    table.ForeignKey(
                        name: "FK_Documents_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fup",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fup", x => x.id);
                    table.ForeignKey(
                        name: "FK_Fup_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgDiag",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(nullable: false),
                    diagnoseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgDiag", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImgDiag_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Makro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(nullable: false),
                    X1 = table.Column<int>(nullable: false),
                    Y1 = table.Column<int>(nullable: false),
                    X2 = table.Column<int>(nullable: false),
                    Y2 = table.Column<int>(nullable: false),
                    bmpos = table.Column<int>(nullable: true),
                    fupId = table.Column<int>(nullable: true),
                    bms_id = table.Column<int>(nullable: true),
                    atbadjustment = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makro", x => x.id);
                    table.ForeignKey(
                        name: "FK_Makro_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mikro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    X_Pic = table.Column<int>(nullable: false),
                    Y_Pic = table.Column<int>(nullable: false),
                    excision = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    ydate = table.Column<DateTime>(nullable: true),
                    exdate = table.Column<DateTime>(nullable: true),
                    zoom = table.Column<int>(nullable: true),
                    makroId = table.Column<int>(nullable: true),
                    closeupId = table.Column<int>(nullable: true),
                    fupId = table.Column<int>(nullable: true),
                    ais_change = table.Column<int>(nullable: true),
                    ais_since = table.Column<int>(nullable: true),
                    treshold = table.Column<int>(nullable: true),
                    trending_action = table.Column<int>(nullable: true),
                    biopsy = table.Column<bool>(nullable: false),
                    oldparent = table.Column<int>(nullable: true),
                    ybiopsydate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mikro", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mikro_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trichoscan",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mikroId = table.Column<int>(nullable: false),
                    version = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    haircount = table.Column<float>(nullable: true),
                    hairdensity = table.Column<float>(nullable: false),
                    area = table.Column<float>(nullable: false),
                    telogen = table.Column<float>(nullable: true),
                    anagen = table.Column<float>(nullable: true),
                    velluscount = table.Column<float>(nullable: true),
                    terminalcount = table.Column<float>(nullable: true),
                    vellusdensity = table.Column<float>(nullable: true),
                    terminaldensity = table.Column<float>(nullable: true),
                    mode_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    haircount_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    hairdensity_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    area_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    anakm_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    telokm_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    anakmdensity_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ratiovell_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ratioterm_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    densityvell_ = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    densityterm_ = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trichoscan", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trichoscan_Mikro_mikroId",
                        column: x => x.mikroId,
                        principalTable: "Mikro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Complexion",
                columns: new[] { "ID", "info" },
                values: new object[,]
                {
                    { 1, "Dark" },
                    { 2, "Fair" },
                    { 3, "Light" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "ID", "info" },
                values: new object[,]
                {
                    { 1, "Australia" },
                    { 2, "China" },
                    { 3, "Japan" },
                    { 4, "USA" }
                });

            migrationBuilder.InsertData(
                table: "DEFBodymapPosition",
                columns: new[] { "id", "X1", "X2", "Y1", "Y2", "bar_location_text", "body_pos_id", "body_type", "dummy_position", "hint_text", "light_intensity_text", "location_text", "other_instruction_text", "position_text", "remark_text" },
                values: new object[,]
                {
                    { 50, 742968276, 1180607123, 630018862, 989061869, "on LIGHT BLUE coloured position", 7, (byte)3, 5, "15329708", "Illumination light is on", "Right flank with arm raised", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 49, 814211809, 1424870666, 108390342, 677439636, "on BLUE coloured position", 6, (byte)3, 5, "14390128", "Illumination light is on", "Right upper arm, anterior, forearm and open hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 48, 1089008295, 2137305999, 1090677814, 2147483647, "on WHITE coloured position", 5, (byte)3, 9, "16777215", "Illumination light is on", "Sole of left foot", "Choose A, B or C sub-position, depend on patient height.", "Sitting in chair", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 47, 10177648, 1048297704, 1090677814, 2147483647, "on WHITE coloured position", 4, (byte)3, 9, "16777215", "Illumination light is on", "Sole of right foot", "Choose A, B or C sub-position, depend on patient height.", "Sitting in chair", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 46, 1089008295, 2137305999, 6774396, 1063580229, "on BLUE coloured position", 3, (byte)3, 7, "14390128", "Illumination light is on", "Left face and neck", "Choose A, B or C sub-position, depend on patient height.", "Sitting in chair", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 45, 10177648, 1048297704, 1090677814, 2147483647, "on BLUE coloured position", 2, (byte)3, 7, "14390128", "Illumination light is on", "Right face and neck", "Choose A, B or C sub-position, depend on patient height.", "Sitting in chair", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 44, 10177648, 1048297704, 6774396, 1063580229, "on BLUE coloured position", 1, (byte)3, 7, "14390128", "Illumination light is on", "Front face and neck", "Choose A, B or C sub-position, depend on patient height.", "Sitting in chair", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 41, 763323571, 1353627133, 1497141596, 2039093305, "on WHITE coloured position", 8, (byte)0, 4, "16777215", "Illumination light is on", "Back of legs (knees down)", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 42, 763323571, 1373982428, 1083903418, 1537787974, "on YELLOW coloured position", 9, (byte)0, 1, "65535", "Illumination light is on", "Upper legs to above knee", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 51, 742968276, 1160251828, 989061869, 1544562371, "on YELLOW coloured position", 8, (byte)3, 5, "65535", "Illumination light is on", "Right thigh and hip", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 40, 763323571, 1353627133, 880671527, 1497141596, "on YELLOW coloured position", 7, (byte)0, 4, "65535", "Illumination light is on", "Waist to back of knee", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 39, 722612981, 1424870666, 108390342, 880671527, "on LIGHT BLUE coloured position", 6, (byte)0, 4, "15329708", "Illumination light is on", "Back of head to waist", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 38, 763323571, 1373982428, 724860411, 1083903418, "on LIGHT BLUE coloured position", 5, (byte)0, 1, "15329708", "Illumination light is on", "Stomach only", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 37, 722612981, 1424870666, 413238178, 914543509, "on LIGHT BLUE coloured position", 4, (byte)0, 1, "15329708", "Illumination light is on", "Neck to chest above navel", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 43, 763323571, 1373982428, 1537787974, 2039093305, "on WHITE coloured position", 10, (byte)0, 1, "16777215", "Illumination light is on", "Both lower legs (knees down)", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 52, 702257686, 1200962419, 1544562371, 2039093305, "on WHITE coloured position", 9, (byte)3, 5, "16777215", "Illumination light is on", "Right lateral calf and foot", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 55, 956698876, 1394337723, 630018862, 989061869, "on LIGHT BLUE coloured position", 12, (byte)3, 3, "15329708", "Illumination light is on", "Left flank with arm raised", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 54, 712435333, 1333271838, 108390342, 677439636, "on BLUE coloured position", 11, (byte)3, 3, "14390128", "Illumination light is on", "Left upper arm, anterior, forearm and open hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 69, 773501219, 1363804781, 1490367200, 2045867702, "on WHITE coloured position", 26, (byte)3, 4, "16777215", "Illumination light is on", "Lower legs, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 68, 559770619, 1577535380, 900994716, 1483592803, "on YELLOW coloured position", 25, (byte)3, 4, "65535", "Illumination light is on", "Buttocks and upper legs, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 67, 559770619, 1577535380, 670665240, 894220320, "on LIGHT BLUE coloured position", 24, (byte)3, 4, "15329708", "Illumination light is on", "Lower back and arm, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 66, 590303562, 1536824790, 291299044, 711311618, "on LIGHT BLUE coloured position", 23, (byte)3, 4, "15329708", "Illumination light is on", "Back of neck, upper back and arm, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 65, 10177648, 2137305999, 1090677814, 2147483647, "on LIGHT BLUE coloured position", 22, (byte)3, 8, "15329708", "Illumination light is on", "Both palms", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 64, 875277695, 1363804781, 1158421778, 2045867702, "on WHITE coloured position", 21, (byte)3, 6, "16777215", "Illumination light is on", "Left inner leg", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 53, 1099185943, 1638601266, 101615945, 657116447, "on BLUE coloured position", 10, (byte)3, 6, "14390128", "Illumination light is on", "Left inner arm and hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 63, 773501219, 1262028304, 1158421778, 2045867702, "on WHITE coloured position", 20, (byte)3, 2, "16777215", "Illumination light is on", "Right inner leg", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 61, 773501219, 1363804781, 1009385058, 1537787974, "on YELLOW coloured position", 18, (byte)3, 1, "65535", "Illumination light is on", "Upper legs, anterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 60, 804034162, 1323094190, 670665240, 1043257040, "on LIGHT BLUE coloured position", 17, (byte)3, 1, "15329708", "Illumination light is on", "Left and right abdomen", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 59, 742968276, 1384160076, 406463782, 711311618, "on LIGHT BLUE coloured position", 16, (byte)3, 1, "15329708", "Illumination light is on", "Left and right chest", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 57, 936343581, 1435048314, 1544562371, 2039093305, "on WHITE coloured position", 14, (byte)3, 3, "16777215", "Illumination light is on", "Left lateral calf and foot", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 56, 977054171, 1394337723, 989061869, 1544562371, "on YELLOW coloured position", 13, (byte)3, 3, "65535", "Illumination light is on", "Left thigh and hip", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 36, 10177648, 1048297704, 1090677814, 2147483647, "on BLUE coloured position", 3, (byte)0, 7, "14390128", "Illumination light is on", "Left side of face", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 62, 773501219, 1363804781, 1537787974, 2045867702, "on WHITE coloured position", 19, (byte)3, 1, "16777215", "Illumination light is on", "Lower legs, anterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 35, 1089008295, 2137305999, 6774396, 1063580229, "on BLUE coloured position", 2, (byte)0, 7, "14390128", "Illumination light is on", "Right side of face", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 58, 498704733, 1038120057, 101615945, 657116447, "on BLUE coloured position", 15, (byte)3, 2, "14390128", "Illumination light is on", "Right inner arm and hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 33, 773501219, 1363804781, 1490367200, 2045867702, "on WHITE coloured position", 33, (byte)1, 4, "16777215", "Illumination light is on", "Lower legs, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 14, 956698876, 1394337723, 630018862, 989061869, "on LIGHT BLUE coloured position", 14, (byte)1, 3, "15329708", "Illumination light is on", "Left flank with arm raised", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 13, 885455343, 1333271838, 487756538, 677439636, "on BLUE coloured position", 13, (byte)1, 3, "14390128", "Illumination light is on", "Left upper arm, anterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 12, 712435333, 977054171, 108390342, 541951709, "on BLUE coloured position", 12, (byte)1, 3, "14390128", "Illumination light is on", "Left forearm and open hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 11, 1099185943, 1638601266, 101615945, 657116447, "on BLUE coloured position", 11, (byte)1, 6, "14390128", "Illumination light is on", "Left inner arm and hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 10, 702257686, 1200962419, 1544562371, 2039093305, "on WHITE coloured position", 10, (byte)1, 5, "16777215", "Illumination light is on", "Right lateral calf and foot", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 9, 742968276, 1160251828, 989061869, 1544562371, "on YELLOW coloured position", 9, (byte)1, 5, "65535", "Illumination light is on", "Right thigh and hip", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 15, 977054171, 1394337723, 989061869, 1544562371, "on YELLOW coloured position", 15, (byte)1, 3, "65535", "Illumination light is on", "Left thigh and hip", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 8, 742968276, 1180607123, 630018862, 989061869, "on LIGHT BLUE coloured position", 8, (byte)1, 5, "15329708", "Illumination light is on", "Right flank with arm raised", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 6, 1160251828, 1424870666, 108390342, 541951709, "on BLUE coloured position", 6, (byte)1, 5, "14390128", "Illumination light is on", "Right forearm and open hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 4, 10177648, 1048297704, 1090677814, 2147483647, "on WHITE coloured position", 4, (byte)1, 9, "16777215", "Illumination light is on", "Sole of right foot", "Choose A, B or C sub-position, depend on patient height.", "Sitting in chair", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 3, 1089008295, 2137305999, 6774396, 1063580229, "on BLUE coloured position", 3, (byte)1, 7, "14390128", "Illumination light is on", "Left face and neck", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 2, 10177648, 1048297704, 1090677814, 2147483647, "on BLUE coloured position", 2, (byte)1, 7, "14390128", "Illumination light is on", "Right face and neck", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 1, 10177648, 1048297704, 6774396, 1063580229, "on BLUE coloured position", 1, (byte)1, 7, "14390128", "Illumination light is on", "Front face and neck", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 34, 10177648, 1048297704, 6774396, 1063580229, "on BLUE coloured position", 1, (byte)0, 7, "14390128", "Illumination light is on", "Face frontal", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 7, 814211809, 1251850657, 487756538, 677439636, "on BLUE coloured position", 7, (byte)1, 5, "14390128", "Illumination light is on", "Right upper arm, anterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Right", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 16, 936343581, 1435048314, 1544562371, 2039093305, "on WHITE coloured position", 16, (byte)1, 3, "16777215", "Illumination light is on", "Left lateral calf and foot", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 5, 1089008295, 2137305999, 1090677814, 2147483647, "on WHITE coloured position", 5, (byte)1, 9, "16777215", "Illumination light is on", "Sole of left foot", "Choose A, B or C sub-position, depend on patient height.", "Sitting in chair", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 18, 1068653000, 1384160076, 406463782, 711311618, "on LIGHT BLUE coloured position", 18, (byte)1, 1, "15329708", "Illumination light is on", "Left chest", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 17, 498704733, 1038120057, 101615945, 657116447, "on BLUE coloured position", 17, (byte)1, 2, "14390128", "Illumination light is on", "Right inner arm and hand", "Choose A, B or C sub-position, depend on patient height.", "Standing Left", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 31, 1068653000, 1577535380, 670665240, 894220320, "on LIGHT BLUE coloured position", 31, (byte)1, 4, "15329708", "Illumination light is on", "Right lower back and arm, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 30, 559770619, 1058475352, 670665240, 894220320, "on LIGHT BLUE coloured position", 30, (byte)1, 4, "15329708", "Illumination light is on", "Left lower back and arm, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 32, 559770619, 1577535380, 900994716, 1483592803, "on YELLOW coloured position", 32, (byte)1, 4, "65535", "Illumination light is on", "Buttocks and upper legs, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 28, 590303562, 1058475352, 406463782, 711311618, "on LIGHT BLUE coloured position", 28, (byte)1, 4, "15329708", "Illumination light is on", "Left upper back and arm, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 27, 905810638, 1231495362, 291299044, 426786971, "on BLUE coloured position", 27, (byte)1, 4, "14390128", "Illumination light is on", "Back of neck", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 26, 10177648, 2137305999, 1090677814, 2147483647, "on LIGHT BLUE coloured position", 26, (byte)1, 8, "15329708", "Illumination light is on", "Both palms", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 29, 1068653000, 1536824790, 406463782, 711311618, "on LIGHT BLUE coloured position", 29, (byte)1, 4, "15329708", "Illumination light is on", "Right upper back and arm, posterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Rear", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 24, 773501219, 1262028304, 1158421778, 2045867702, "on WHITE coloured position", 24, (byte)1, 2, "16777215", "Illumination light is on", "Right inner leg", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 23, 773501219, 1363804781, 1537787974, 2045867702, "on WHITE coloured position", 23, (byte)1, 1, "16777215", "Illumination light is on", "Lower legs, anterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 22, 773501219, 1363804781, 1009385058, 1537787974, "on YELLOW coloured position", 22, (byte)1, 1, "65535", "Illumination light is on", "Upper legs, anterior", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 21, 804034162, 1058475352, 670665240, 1043257040, "on LIGHT BLUE coloured position", 21, (byte)1, 1, "15329708", "Illumination light is on", "Right abdomen", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 20, 1068653000, 1323094190, 670665240, 1043257040, "on LIGHT BLUE coloured position", 20, (byte)1, 1, "15329708", "Illumination light is on", "Left abdomen", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 25, 875277695, 1363804781, 1158421778, 2045867702, "on WHITE coloured position", 25, (byte)1, 6, "16777215", "Illumination light is on", "Left inner leg", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." },
                    { 19, 742968276, 1058475352, 406463782, 711311618, "on LIGHT BLUE coloured position", 19, (byte)1, 1, "15329708", "Illumination light is on", "Right chest", "Choose A, B or C sub-position, depend on patient height.", "Standing Front", "For this position follow-up, use the same camera bar position and sub position (A, B or C)." }
                });

            migrationBuilder.InsertData(
                table: "DEFDiagnoses",
                columns: new[] { "id", "category", "favorite", "fullname", "origin_id", "parent_id", "risk", "shortname" },
                values: new object[,]
                {
                    { 597, 0, 0, "Pityriasis rubra pilaris", 613, 409, "S", null },
                    { 596, 0, 0, "Pityriasis rosea with herald patch", 612, 833, "S", null },
                    { 595, 0, 0, "Pityriasis rosea with annular scales", 611, 833, "S", null },
                    { 594, 0, 0, "Pityriasis rosea of the groin", 610, 833, "S", null },
                    { 591, 0, 0, "Pityriasis amiantacea in a child", 607, 720, "S", null },
                    { 592, 0, 0, "Pityriasis amiantacea in an adult", 608, 720, "S", null },
                    { 590, 0, 0, "Pitted keratolysis", 606, 116, "S", null },
                    { 588, 0, 0, "Pilomatrixoma", 604, 282, "S", null },
                    { 589, 0, 0, "Pincer nails", 605, 538, "S", null },
                    { 593, 0, 0, "Pityriasis rosea", 609, 833, "S", null },
                    { 598, 0, 0, "Pityriasis versicolor in summer (temperate climate)", 614, 575, "S", null },
                    { 605, 0, 0, "Plantar warts - regression", 621, 835, "S", null },
                    { 600, 0, 0, "Pityriasis versicolor.", 616, 575, "S", null },
                    { 601, 0, 0, "Pityrosporum folliculitis", 617, 575, "S", null },
                    { 602, 0, 0, "Plane warts on a hand", 618, 835, "S", null },
                    { 603, 0, 0, "Plantar mosaic warts", 619, 835, "S", null },
                    { 604, 0, 0, "Plantar wart", 620, 835, "S", null },
                    { 606, 0, 0, "Plantar warts in an hepatic transplant patient", 622, 835, "S", null },
                    { 607, 0, 0, "Plaque-type psoriasis", 623, 649, "S", null },
                    { 608, 0, 0, "Plaque-type psoriasis of the genitals", 624, 649, "S", null },
                    { 609, 0, 0, "Plaque-type psoriasis of the scalp", 625, 649, "S", null },
                    { 587, 0, 0, "Pili torti", 603, 262, "S", null },
                    { 610, 0, 0, "Plasma cell balanitis", 626, 885, "S", null },
                    { 599, 0, 0, "Pityriasis versicolor in winter (temperate climate)", 615, 575, "S", null },
                    { 586, 0, 1, "Pigmented Spitz's Nevus", 602, -1, "S", null },
                    { 569, 0, 0, "Pemphigus foliaceus", 584, 149, "S", null },
                    { 584, 0, 1, "Pigmented Basal Cell Carcinoma", 600, -1, "AR", null },
                    { 611, 0, 0, "Poikiloderma Civatte", 627, 688, "S", null },
                    { 560, -1, 0, "Oral pathology", 573, 736, "", null },
                    { 561, 0, 0, "Osler Randu Weber disease", 574, 739, "S", null },
                    { 562, -1, 0, "Other Yeast Infections", 575, 162, "S", null },
                    { 563, 0, 0, "Oxyuriasis", 576, 738, "S", null },
                    { 564, 0, 0, "Painful piazzogenic pedal papules", 579, 823, "S", null },
                    { 565, 0, 0, "Palmar erythema", 580, 823, "S", null },
                    { 566, 0, 0, "Paraphimosis", 581, 885, "S", null },
                    { 567, 0, 0, "Parapsoriasis en plaques", 582, 474, "S", null },
                    { 568, 0, 0, "Pellagra", 583, 739, "S", null },
                    { 570, 0, 0, "Pemphigus vulgaris", 585, 149, "S", null },
                    { 585, -1, 0, "Pigmented lesions", 601, 812, "", null },
                    { 571, 0, 0, "Pemphigus vulgaris of the oral mucosa", 586, 149, "S", null },
                    { 573, 0, 0, "Perianal condylomas", 589, 885, "AR", null },
                    { 574, 0, 0, "Perianal streptococcal infection in a child", 590, 116, "S", null },
                    { 575, 0, 0, "Perianal streptococcal infection in an adult", 591, 116, "S", null },
                    { 576, 0, 0, "Periungual abscess", 592, 116, "S", null },
                    { 577, 0, 0, "Periungual psoriasiform dermatitis caused by metoprolol", 593, 266, "S", null },
                    { 578, 0, 0, "Periungual vesicular hand eczema", 594, 349, "S", null },
                    { 579, 0, 0, "Perniosis", 595, 823, "S", null },
                    { 580, 0, 0, "Peutz Jehger's disease", 596, 739, "S", null },
                    { 581, 0, 0, "Phenylketonuria", 597, 739, "S", null },
                    { 582, 0, 0, "Phlebectasia", 598, 823, "S", null },
                    { 583, -1, 0, "Pigmentary disorders", 599, 209, "", null },
                    { 572, 0, 0, "Penile pearly papules", 588, 885, "S", null },
                    { 613, 0, 0, "Pomade acne following the use of a hair gel", 629, 884, "S", null },
                    { 651, 0, 0, "Psoriasis Vulgaris Chronic Stable State", 667, 666, "S", null },
                    { 615, 0, 0, "Porphyria cutanea tarda", 631, 739, "S", null },
                    { 644, 0, 0, "Psoriasis of the hand", 660, 649, "S", null },
                    { 645, 0, 0, "Psoriasis of the nails", 661, 649, "S", null },
                    { 646, 0, 0, "Psoriasis of the nails - oil drops and onycholysis", 662, 649, "S", null },
                    { 647, 0, 0, "Psoriasis of the nails - onycholysis and subungual lesions", 663, 381, "S", null },
                    { 648, 0, 0, "Psoriasis of the nails - pitting", 664, 649, "S", null },
                    { 649, -1, 0, "Psoriasis Pustular", 665, 649, "S", null },
                    { 650, -1, 0, "Psoriasis Vulgaris", 666, 649, "S", null },
                    { 559, 0, 0, "Onychotillomania", 572, 808, "S", null },
                    { 652, 0, 0, "Psoriasis - Exfoliative erythroderma", 668, 649, "S", null },
                    { 653, 0, 0, "Psoriasis - Koebner lesion", 669, 649, "S", null },
                    { 654, 0, 0, "Pulpitis", 670, 350, "S", null },
                    { 643, 0, 0, "Psoriasis of the face", 659, 649, "S", null },
                    { 655, 0, 0, "Punctate keratoderma", 671, 409, "S", null },
                    { 657, 0, 0, "Purpura caused by kissing (suction)", 673, 672, "S", null },
                    { 658, 0, 0, "Purpura following vomiting", 674, 672, "S", null },
                    { 659, 0, 0, "Purpura pigmentosa chronica", 675, 672, "S", null },
                    { 660, 0, 0, "Purpura pigmentosa chronica. Pigment does not fade after pressure with a glass spatula is applied", 676, 672, "S", null },
                    { 661, 0, 0, "Pustular bacterid", 677, 739, "S", null },
                    { 662, 0, 0, "Pustular plantar psoriasis", 678, 680, "S", null },
                    { 663, 0, 0, "Pustular psoriasis", 679, 680, "S", null },
                    { 664, -1, 0, "Pustular Psoriasis and Other Pustular Disorders", 680, 649, "S", null },
                    { 665, 0, 0, "Pustular Psoriasis Generalised Acute", 681, 665, "S", null },
                    { 666, 0, 0, "Pustulosis palmo-plantaris", 682, 680, "S", null },
                    { 667, 0, 0, "Pyoderma gangrenosum", 683, 823, "S", null },
                    { 656, -1, 0, "Purpura", 672, 209, "S", null },
                    { 614, 0, 0, "Pompholyx (a close-up)", 630, 349, "S", null },
                    { 642, 0, 0, "Psoriasis nail", 658, 649, "S", null },
                    { 640, 0, 0, "Psoriasis Guttate", 656, 649, "S", null },
                    { 616, 0, 0, "Porphyria cutanea tarda with hypertrichosis", 632, 739, "S", null },
                    { 617, 0, 0, "Post scabies nodules", 633, 738, "S", null },
                    { 618, 0, 0, "Post-febrile telogen hair loss", 634, 83, "S", null },
                    { 619, 0, 0, "Post-infectious peeling of the skin", 635, 116, "S", null },
                    { 620, 0, 0, "Pressure ulceration of the ankle", 636, 823, "S", null },
                    { 621, 0, 0, "Pressure ulceration of the gluteal region", 637, 823, "S", null },
                    { 622, 0, 0, "Pressure urticaria from kneeling", 638, 817, "S", null },
                    { 623, 0, 0, "Pretibial myxoedema", 639, 739, "S", null },
                    { 624, 0, 0, "Protein contact dermatitis from wheat in a pizza baker", 640, 349, "S", null },
                    { 625, 0, 0, "Prurigo nodularis Hyde", 641, 823, "S", null },
                    { 626, 0, 0, "Pseudoacanthosis nigricans", 642, 739, "S", null },
                    { 641, 0, 0, "Psoriasis in a child", 657, 649, "S", null },
                    { 627, 0, 0, "Pseudofolliculitis in the area of the beard", 643, 116, "S", null },
                    { 629, 0, 0, "Pseudoporphyria after intense use of tanning bed", 645, 739, "S", null },
                    { 630, 0, 0, "Pseudoporphyria caused by high-dose furosemide", 646, 266, "S", null },
                    { 631, 0, 0, "Pseudoxanthoma elasticum", 647, 823, "S", null },
                    { 632, 0, 0, "Psoriasiform dermatitis caused by a beta-blocking drug", 648, 266, "S", null },
                    { 633, -1, 0, "Psoriasis", 649, 209, "S", null },
                    { 634, 0, 0, "Psoriasis - nail changes and arthropathy", 650, 381, "S", null },
                    { 635, 0, 0, "Psoriasis - severe destructive nail changes in an alcoholic", 651, 381, "S", null },
                    { 636, 0, 0, "Psoriasis aggravated by sun", 652, 649, "S", null },
                    { 637, 0, 0, "Psoriasis arthritis", 653, 649, "S", null },
                    { 638, 0, 0, "Psoriasis erythroderma", 654, 649, "S", null },
                    { 639, 0, 0, "Psoriasis foot", 655, 649, "S", null },
                    { 628, 0, 0, "Pseudopelade", 644, 84, "S", null },
                    { 558, 0, 0, "Onychophagia", 571, 808, "S", null },
                    { 520, 0, 0, "nail dystrophy", 533, -1, "S", null },
                    { 556, 0, 0, "Onychomycosis", 569, 249, "S", null },
                    { 476, 0, 0, "Malignant melanoma - superficial spreading type", 484, 479, "MR", null },
                    { 477, 0, 0, "Malignant melanoma metastases", 485, 479, "MR", null },
                    { 478, 0, 0, "Malignant melanoma with regression", 486, 479, "MR", null },
                    { 479, -1, 0, "Malignant tumours", 487, 812, "MR", null },
                    { 480, 0, 0, "Malnutrition", 488, 739, "S", null },
                    { 481, 0, 0, "Malnutrition with zinc deficiency in an alcoholic", 489, 739, "S", null },
                    { 482, 0, 0, "Mastocytoma", 490, 819, "S", null },
                    { 483, 0, 0, "Mastocytoma after rubbing the area shown in 3-68", 491, 819, "S", null },
                    { 484, 0, 0, "Mastocytosis", 492, 819, "S", null },
                    { 485, 0, 0, "Mastocytosis Solitary Mastocytoma", 493, 819, "S", null },
                    { 486, 0, 0, "Measles", 494, 834, "S", null },
                    { 475, 0, 0, "Malignant melanoma - nodular", 483, 479, "MR", null },
                    { 487, 0, 0, "Mechanical dermatitis from rubbing the skin", 495, 217, "S", null },
                    { 489, 0, 0, "Melasma", 497, 599, "S", null },
                    { 490, 0, 0, "Metastatic Cancer to the Skin", 499, 228, "AR", null },
                    { 491, 0, 0, "Metastatic Melanoma", 500, 479, "MR", null },
                    { 492, 0, 0, "Milia", 501, 282, "S", null },
                    { 493, 0, 0, "Milia - posttraumatic", 502, 282, "S", null },
                    { 494, -1, 0, "Miliaria", 503, 689, "S", null },
                    { 495, 0, 0, "Miliaria crystallina", 504, 263, "S", null }
                });

            migrationBuilder.InsertData(
                table: "DEFDiagnoses",
                columns: new[] { "id", "category", "favorite", "fullname", "origin_id", "parent_id", "risk", "shortname" },
                values: new object[,]
                {
                    { 496, 0, 0, "Miliaria rubra", 505, 504, "S", null },
                    { 497, 0, 0, "Mixed connective tissue disease", 506, 201, "S", null },
                    { 498, 0, 0, "Molluscum contagiosum", 507, 834, "S", null },
                    { 499, 0, 0, "Molluscum contagiosum in a man", 508, 885, "S", null },
                    { 488, 0, 0, "Mechanical dermatitis from rubbing the thighs together", 496, 217, "S", null },
                    { 500, 0, 0, "Molluscum contagiosum in a woman", 509, 885, "S", null },
                    { 474, 0, 0, "Malignant melanoma - acral with metastases", 482, 479, "MR", null },
                    { 472, 0, 0, "Malignant melanoma - acral amelanotic", 480, 479, "MR", null },
                    { 448, 0, 0, "Linear Morphea", 455, 201, "S", null },
                    { 449, 0, 0, "Lingua scrotalis", 456, 573, "S", null },
                    { 450, 0, 0, "Lipoatrophy (subcutaneous fat necrosis) in a newborn", 457, 110, "S", null },
                    { 451, 0, 0, "Lipoatrophy of the left leg", 458, 110, "S", null },
                    { 452, 0, 0, "Lipoma", 459, 765, "S", null },
                    { 453, 0, 0, "Lipomas - multiple", 460, 765, "S", null },
                    { 454, 0, 0, "Livedoid Vasculitis", 461, 823, "S", null },
                    { 455, 0, 0, "Livedovasculitis", 462, 823, "S", null },
                    { 456, 0, 0, "Low-humidity dermatosis caused by a car heater, with hot air directed towards the legs", 463, 273, "S", null },
                    { 457, -1, 0, "Lupus Erythematosus", 464, 209, "S", null },
                    { 458, 0, 0, "Lupus erythematosus around fingernails", 465, 464, "S", null },
                    { 473, 0, 0, "Malignant melanoma - acral lentiginous", 481, 479, "MR", null },
                    { 459, 0, 0, "Lupus erythematosus disseminatus of the paronychion", 466, 381, "S", null },
                    { 461, 0, 0, "Lupus vulgaris", 468, 116, "S", null },
                    { 462, -1, 0, "Lymphangioma", 469, 136, "S", null },
                    { 463, 0, 0, "Lymphangioma (Lymphatic Malformation)", 470, 469, "S", null },
                    { 464, 0, 0, "Lymphocytoma", 471, 474, "S", null },
                    { 465, 0, 0, "Lymphocytoma - Spiegler Fendt", 472, 474, "S", null },
                    { 466, 0, 0, "Lymphoedema", 473, 823, "S", null },
                    { 467, -1, 0, "Lymphomas and Other Tumours", 474, 812, "", null },
                    { 468, 0, 0, "Male-pattern hair loss in a man", 475, 83, "S", null },
                    { 469, 0, 0, "Male-pattern hair loss in a woman", 476, 83, "S", null },
                    { 470, 0, 0, "Malherbe's epithelioma", 477, 282, "S", null },
                    { 471, -1, 0, "Malignant Melanoma", 479, 601, "MR", null },
                    { 460, 0, 0, "Lupus Panniculitis", 467, 201, "S", null },
                    { 557, 0, 0, "Onychomycosis and dermatophytosis", 570, 249, "S", null },
                    { 501, 0, 0, "Mondor's thrombophlebitis of the chest wall", 510, 823, "S", null },
                    { 503, 0, 0, "Morphaea", 512, 715, "S", null },
                    { 532, 0, 0, "Necrosis caused by metotrexate", 545, 266, "S", null },
                    { 533, 0, 0, "Neurofibromatosis Recklinghausen", 546, 239, "S", null },
                    { 534, 0, 1, "Nevus coeruleus", 547, -1, "S", null },
                    { 535, 0, 0, "Nickel dermatitis from brassiere clasps", 548, 58, "S", null },
                    { 536, 0, 0, "Nickel dermatitis from jeans buttons", 549, 58, "S", null },
                    { 537, 0, 0, "Nickel dermatitis from spectacle frames", 550, 58, "S", null },
                    { 538, 0, 0, "Nickel dermatitis from tiny metal parts of a plastic watchband", 551, 58, "S", null },
                    { 539, 0, 0, "Nickel dermatitis on the earlobe", 552, 58, "S", null },
                    { 540, 0, 0, "Nodular Basal cell carcinoma", 553, 118, "AR", null },
                    { 541, 0, 0, "Nodular dermatitis caused by aluminium", 554, 58, "S", null },
                    { 542, 0, 0, "Nodular dermatitis caused by aluminium in a vaccine against childhood diseases", 555, 58, "S", null },
                    { 531, 0, 0, "Necrosis caused by coumarin", 544, 266, "S", null },
                    { 543, 0, 1, "Nodular Melanoma", 556, 479, "MR", null },
                    { 545, 0, 0, "Norwegian scabies", 558, 738, "S", null },
                    { 546, 0, 1, "Not Diagnostic", 559, -1, "S", null },
                    { 547, 0, 0, "Notalgia paraestetica", 560, 823, "S", null },
                    { 548, -1, 0, "Nummular Eczema", 561, 280, "S", null },
                    { 549, 0, 0, "Nummular eczema of the arms", 562, 561, "S", null },
                    { 550, 0, 0, "Nummular eczema of the hands", 563, 561, "S", null },
                    { 551, 0, 0, "Nummular eczema of the legs", 564, 561, "S", null },
                    { 552, 0, 0, "Oedema of the leg", 565, 823, "S", null },
                    { 553, 0, 0, "Onychodystrophy", 566, 808, "S", null },
                    { 554, 0, 0, "Onychogryposis", 567, 538, "S", null },
                    { 555, -1, 0, "Onycholysis", 568, 539, "S", null },
                    { 544, -1, 0, "Non-Melanoma Skin cancers", 557, 487, "AR", null },
                    { 502, 0, 0, "Mononucleosis", 511, 833, "S", null },
                    { 530, 0, 0, "Necrosis caused by a caustic substance", 543, 217, "S", null },
                    { 528, 0, 0, "Nasal Staphylococcus aureus carriage", 541, 116, "S", null },
                    { 504, 0, 0, "Morphaea en coup de sabre", 513, 715, "S", null },
                    { 505, 0, 0, "Morphea-like late borreliosis", 514, 116, "S", null },
                    { 506, 0, 0, "Mycosis fungoides", 515, 474, "S", null },
                    { 507, 0, 0, "Myxoedema", 516, 739, "S", null },
                    { 508, 0, 0, "Myxoid cyst", 517, 239, "S", null },
                    { 509, 0, 0, "Myxoid cyst with nail depression", 518, 239, "S", null },
                    { 510, 0, 0, "Naevi - compound", 520, 902, "AR", null },
                    { 511, 0, 0, "Naevi - intradermal", 521, 902, "S", null },
                    { 512, 0, 0, "Naevi - intradermal without pigment", 522, 902, "S", null },
                    { 513, 0, 0, "Naevi - intradermal, with pigment", 523, 902, "S", null },
                    { 514, 0, 0, "Naevus anemicus ", 526, 354, "S", null },
                    { 529, 0, 0, "Necrobiosis Lipoidica", 542, 823, "S", null },
                    { 515, 0, 0, "Naevus spilus", 527, 902, "S", null },
                    { 517, -1, 0, "Nail Bacterial Infections", 530, 539, "S", null },
                    { 518, -1, 0, "Nail Changes Associated with Other Diseases", 531, 539, "S", null },
                    { 519, -1, 0, "Nail changes Due to Tumours", 532, 539, "S", null },
                    { 668, 0, 0, "Pyogenic granuloma", 684, 354, "S", null },
                    { 521, 0, 0, "Nail dystrophy seen in an alcoholic", 534, 531, "S", null },
                    { 522, -1, 0, "Nail Fungal Infections", 535, 539, "S", null },
                    { 523, 0, 0, "Nail infection with Aspergillus", 536, 535, "S", null },
                    { 524, 0, 0, "Nail infection with Pseudomonas aeruginosa", 537, 530, "S", null },
                    { 525, -1, 0, "Nail Malformations", 538, 539, "S", null },
                    { 526, -1, 0, "Nails", 539, 736, "", null },
                    { 527, 0, 0, "Napkin dermatitis under the plastic part of the diaper (napkin)", 540, 217, "S", null },
                    { 516, 0, 0, "Naevus with terminal hair", 528, 902, "S", null },
                    { 669, 0, 0, "Pyogenic granuloma with satellite lesions", 685, 354, "S", null },
                    { 707, 0, 0, "Seborrhoeic dermatitis of the scalp", 723, 720, "S", null },
                    { 671, 0, 0, "Raynaud's Syndrome", 687, 209, "S", null },
                    { 812, 0, 0, "Viral exanthema caused by adenovirus", 831, 833, "S", null },
                    { 813, 0, 0, "Viral exanthema of Gianotti-Crosti type", 832, 833, "S", null },
                    { 814, -1, 0, "Viral Exanthemas", 833, 689, "S", null },
                    { 815, -1, 0, "Viral infections", 834, 380, "S", null },
                    { 816, -1, 0, "Viral Warts", 835, 834, "", null },
                    { 817, -1, 0, "Vitiligo", 836, 209, "S", null },
                    { 818, 0, 0, "White forelock", 838, 236, "S", null },
                    { 819, 0, 0, "White regrowth of hair after alopecia areata", 839, 236, "S", null },
                    { 820, 0, 0, "W-napkin dermatitis", 840, 217, "S", null },
                    { 821, 0, 0, "Xanthomas", 841, 739, "S", null },
                    { 822, 0, 0, "Yaws", 842, 885, "S", null },
                    { 811, 0, 0, "Vibration-induced \"white fingers\"", 830, 201, "S", null },
                    { 823, 0, 0, "Yellow nails", 843, 531, "S", null },
                    { 825, 0, 0, "Ichthyosis", 845, 375, "S", null },
                    { 826, 0, 0, "Vitiligo", 846, 599, "S", null },
                    { 827, 0, 0, "Calcification caused by manual distributionof fertilizer (Chile salpeter)", 847, 739, "S", null },
                    { 828, 0, 0, "Black Heel", 848, 823, "S", null },
                    { 829, 0, 0, "Lichen sclerosus et atrophicus in a girl", 849, 823, "S", null },
                    { 830, 0, 0, "Lichen sclerosus et atrophicus in a man", 850, 823, "S", null },
                    { 831, 0, 0, "Lichen sclerosus et atrophicus in a woman ", 851, 823, "S", null },
                    { 832, -1, 0, "Exogenous", 852, 240, "", null },
                    { 833, 0, 0, "A baby with excoriated atopic dermatitis of the face and scalp", 853, 103, "S", null },
                    { 834, 0, 0, "Atopic Dermatitis", 854, 103, "S", null },
                    { 835, 0, 0, "Ababy with an infantile variant of seborrhoeic dermatititis", 855, 720, "S", null },
                    { 824, 0, 0, "Zinc deficiency in a baby", 844, 739, "S", null },
                    { 836, 0, 0, "Seborrhoeic Dermatitis", 856, 720, "S", null },
                    { 810, 0, 0, "Vesicular eczema on a foot", 829, 217, "S", null },
                    { 808, 0, 0, "Verruca vulgaris - exophytic", 827, 835, "S", null },
                    { 784, 0, 0, "Tinea of the trunk (Trichophyton rubrum)", 803, 249, "S", null },
                    { 785, 0, 0, "Tinea Pedis", 804, 782, "S", null },
                    { 786, 0, 0, "Tinea Ungrum", 805, 782, "S", null },
                    { 787, 0, 0, "Tophi", 806, 739, "S", null },
                    { 788, 0, 0, "Traumatic hair loss in a newborn", 807, 83, "S", null },
                    { 789, 0, 0, "Traumatic Nail Changes", 808, 539, "S", null },
                    { 790, 0, 0, "Trichoepitheliomas", 809, 282, "S", null },
                    { 791, 0, 0, "Trichomycosis axillaris", 810, 116, "S", null },
                    { 792, 0, 0, "Trichotillomania with broken hairs", 811, 83, "S", null },
                    { 793, -1, 0, "Tumours", 812, -1, "", null },
                    { 794, 0, 0, "Tunga penetrans", 813, 738, "S", null },
                    { 809, 0, 0, "Verruca vulgaris Koebner phenomenon", 828, 835, "S", null },
                    { 795, 0, 0, "Ulcerative lichen planus", 814, 573, "S", null },
                    { 797, 0, 0, "Universal Vitiligo", 816, 836, "S", null },
                    { 798, -1, 0, "Urticaria", 817, 690, "S", null },
                    { 799, 0, 0, "Urticaria in a child", 818, 817, "S", null },
                    { 800, -1, 0, "Urticaria Pigmentosa", 819, 817, "S", null },
                    { 801, 0, 0, "Urticarial dermatographism", 820, 817, "S", null },
                    { 802, 0, 0, "Urticarial vasculitis", 821, 823, "S", null },
                    { 803, 0, 0, "Varicella", 822, 834, "S", null },
                    { 804, -1, 0, "Vascular Disorders", 823, 209, "", null },
                    { 805, 0, 0, "Vasculitis caused by ibumetine", 824, 266, "S", null },
                    { 806, 0, 0, "Venous lake", 825, 354, "S", null },
                    { 807, 0, 0, "Verruca labialis", 826, 835, "S", null },
                    { 796, 0, 0, "Ulerythema oophrygenes", 815, 83, "S", null },
                    { 783, 0, 0, "Tinea of the sacral area (Trichophyton rubrum)", 802, 249, "S", null },
                    { 837, 0, 0, "A positive patch test to 2% aluminium chloride in water and a Finn chamber made of aluminium", 857, 58, "S", null },
                    { 839, 0, 0, "Allergic contact dermatitis from parabens in a Unna boot I", 859, 58, "S", null },
                    { 868, 0, 0, "Traction alopecia caused by wearing the hair in a tight ponytail", 888, 83, "S", null },
                    { 869, 0, 0, "Albinism", 889, 236, "AR", null },
                    { 870, 0, 0, "Psoriasis of the nails - pitting", 890, 381, "S", null },
                    { 871, 0, 0, "Periungual abscess", 891, 530, "S", null },
                    { 872, 0, 0, "Onychomycosis", 892, 535, "S", null },
                    { 873, 0, 0, "20 nail dystrophy", 893, 538, "S", null },
                    { 874, 0, 0, "Traumatic Nail Changes following sports", 894, 538, "S", null },
                    { 875, 0, 0, "Onycholysis", 895, 568, "S", null },
                    { 876, 0, 0, "Lichen planus of oral mucosa", 896, 573, "S", null },
                    { 877, 0, 0, "Lupus Erythematosus", 897, 573, "S", null },
                    { 878, 0, 0, "Dermatofibroma", 898, 239, "S", null },
                    { 867, 0, 0, "Reiter's disease", 887, 885, "S", null },
                    { 879, 0, 0, "Cutaneous Metastases", 899, 228, "AR", null },
                    { 881, 0, 0, "Basal Cell Carcinoma", 901, 118, "AR", null },
                    { 882, 0, 0, "Basal Cell Carcinoma", 902, 557, "AR", null },
                    { 883, 0, 0, "Lentigo Maligna", 903, 479, "MR", null },
                    { 884, 0, 0, "Lentigo Maligna Melanoma", 904, 479, "MR", null },
                    { 885, 0, 0, "Malignant Melanoma", 905, 479, "MR", null },
                    { 886, 0, 0, "Drug Reaction", 906, 266, "S", null },
                    { 887, 0, 0, "Tinea caused by Microsporum canis in 3 siblings who had played with the same kitten", 907, 249, "S", null },
                    { 888, 0, 0, "Urticaria", 908, 817, "S", null },
                    { 889, 0, 0, "Superficial white onychomycosis", 909, 535, "S", null },
                    { 890, 0, 0, "Onycholysis, traumatic occupational in a slaughterhouse worker from removing hog hides ", 910, 568, "S", null },
                    { 891, -1, 0, "Benign", 911, 601, "", null },
                    { 880, 0, 0, "Squamous Cell Carcinoma", 900, 487, "AR", null },
                    { 838, 0, 0, "Allergic contact dermatitisfrom glue in sticking plaster in a patient allergic to colophony and from colophony in a remedy used to treat a wart", 858, 58, "S", null },
                    { 866, 0, 0, "Acne following treatment with Antabuse®", 886, 884, "S", null },
                    { 864, -1, 0, "Acne and related diseases", 884, 736, "", null },
                    { 840, 0, 0, "Allergic contact dermatitis from plants in the compositae family I", 860, 58, "S", null },
                    { 841, 0, 0, "Allergic contact dermatitis from plants in the compositae family II", 861, 58, "S", null },
                    { 842, 0, 0, "Allergic contact dermatitis from plants in the compositae family III", 862, 58, "S", null },
                    { 843, 0, 0, "Allergic contact dermatitis from toluenesulfonyl urea in nail varnish I", 863, 58, "S", null },
                    { 844, 0, 0, "Dermatitis of the buttocks in a child with enoresis nocturna", 864, 217, "S", null },
                    { 845, 0, 0, "Stoma dermatitis I", 865, 217, "S", null },
                    { 846, 0, 0, "Nummular eczema of the hands", 866, 349, "S", null },
                    { 847, 0, 0, "Eczema nails (transverse groove on the nails in approximation to hand eczema", 867, 350, "S", null },
                    { 848, 0, 0, "Lichen Simplex chronicus", 868, 447, "S", null },
                    { 849, 0, 0, "Drug Induced Photosensitivity", 869, 265, "S", null },
                    { 850, 0, 0, "A child with a drug eruption from erythromycin", 870, 266, "S", null },
                    { 865, -1, 0, "Genitopathology", 885, 736, "", null },
                    { 851, 0, 0, "A drug eruption from penicilin in a girl with an upper respiratory tract infection", 871, 266, "S", null },
                    { 853, 0, 0, "Candidiasis in the napkin area", 873, 162, "S", null },
                    { 854, 0, 0, "Candidiasis next to leg ulcer", 874, 162, "S", null },
                    { 855, 0, 0, "Tinea corporis (Trichophyton mentagrophytes) in two brothers", 875, 249, "S", null },
                    { 856, 0, 0, "Dermatitis herpetiformis of a leg (amputation under the knee)", 876, 149, "S", null },
                    { 857, 0, 0, "Herpes Gestationis", 877, 149, "S", null },
                    { 858, 0, 0, "Herpes Gestationis in the infant of a mother with herpes gestationis", 878, 149, "S", null },
                    { 859, 0, 0, "Pressure induced bullae (decubitus) in the top part of the illustration (gluteal region)", 879, 149, "S", null },
                    { 860, 0, 0, "Bullous erythema multiforme", 880, 295, "S", null },
                    { 861, 0, 0, "Bullous lichen planus of the lower leg", 881, 433, "S", null },
                    { 862, 0, 0, "Lichen Planus", 882, 433, "S", null },
                    { 863, 0, 0, "Hand-foot-mouth disease", 883, 833, "S", null },
                    { 852, 0, 0, "Candidiasis", 872, 162, "S", null },
                    { 670, 0, 0, "Quininie Drug Reaction", 686, 266, "S", null },
                    { 782, 0, 0, "Tinea of the right hand (Trichophyton rubrum)", 801, 249, "S", null },
                    { 780, 0, 0, "Tinea of the right foot (Trichophyton mentagrophytes)", 799, 249, "S", null },
                    { 700, 0, 0, "Scleroderma with periungual telangiectasies", 716, 715, "S", null },
                    { 701, 0, 0, "Sebaceous cyst", 717, 282, "S", null },
                    { 702, 0, 0, "Sebaceous hyperplasia", 718, 282, "S", null },
                    { 703, 0, 0, "Sebaceous naevus", 719, 282, "S", null },
                    { 704, -1, 0, "Seborrhoeic Dermatitis", 720, 280, "S", null },
                    { 705, 0, 0, "Seborrhoeic dermatitis of the chest", 721, 720, "S", null },
                    { 706, 0, 0, "Seborrhoeic dermatitis of the face", 722, 720, "S", null },
                    { 447, 0, 0, "Linear IgA dermatosis", 454, 149, "S", null },
                    { 708, 0, 0, "Seborrhoeic keratoses", 724, 282, "S", null },
                    { 709, 0, 0, "Secondarily infected hand eczema", 726, 217, "S", null },
                    { 710, 0, 0, "Secondarily infected irritant dermatitis of the fingerweb", 727, 217, "S", null },
                    { 699, -1, 0, "Scleroderma", 715, 209, "S", null },
                    { 711, 0, 0, "Secondarily infected perlêche", 728, 217, "S", null },
                    { 713, 0, 0, "Segmental giant pigmented naevus", 730, 902, "AR", null },
                    { 714, 0, 0, "Senile angiomas", 731, 354, "S", null },
                    { 715, 0, 0, "Senile elastosis - Favre Racouchot", 732, 884, "S", null },
                    { 716, 0, 0, "Senile purpura", 733, 672, "S", null },
                    { 717, 0, 0, "Severe psoriasis on a foot", 734, 649, "S", null },
                    { 718, 0, 0, "Sister Mary Joseph's nodule", 735, 228, "S", null },
                    { 719, -1, 0, "Skin Adnexa and Special Locations", 736, -1, "", null },
                    { 720, 0, 0, "Skin diseases caused by fungi", 737, 380, "S", null },
                    { 721, -1, 0, "Skin diseases caused by parasites", 738, 380, "S", null },
                    { 722, -1, 0, "Skin Lesions in Internal Disease", 739, 209, "", null },
                    { 723, 0, 0, "Skin tags", 740, 239, "S", null },
                    { 712, 0, 0, "Secondary syphilis", 729, 885, "S", null },
                    { 724, 0, 0, "Smegma pudendi", 741, 885, "S", null },
                    { 698, 0, 0, "Scleredema Buschke", 714, 823, "S", null },
                    { 696, 0, 0, "Scalp Psoriasis", 712, 649, "S", null },
                    { 672, -1, 0, "Reactions to Cold and Sun", 688, 240, "S", null },
                    { 673, -1, 0, "Reactive Erythemas", 689, 690, "S", null },
                    { 674, -1, 0, "Reactive Erythemas and Exanthemas", 690, -1, "S", null },
                    { 675, 0, 0, "Recurrent vesicular dermatitis of the fingers (Systemic contact dermatitis)", 691, 350, "S", null },
                    { 676, 0, 0, "Recurrent vesicular hand eczema (Systemic contact dermatitis in a nickel allergic person)", 692, 350, "S", null },
                    { 677, 0, 0, "Reiter's disease", 693, 739, "S", null },
                    { 678, 0, 0, "Relapsing polychondritis", 694, 823, "S", null },
                    { 679, 0, 0, "Reticulohistiocytoma", 695, 474, "S", null },
                    { 680, 0, 0, "Rheumatic nodules", 696, 739, "S", null },
                    { 681, 0, 0, "Rheumatoid arthritis", 697, 739, "S", null },
                    { 682, 0, 0, "Rhinophyma", 698, 110, "S", null },
                    { 697, 0, 0, "Scars following severe acne", 713, 29, "S", null },
                    { 683, 0, 0, "Rhinophyma following rosacea", 699, 703, "S", null },
                    { 685, 0, 0, "Rosacea", 701, 703, "S", null },
                    { 686, 0, 0, "Rosacea - Stage 3", 702, 703, "S", null },
                    { 687, -1, 0, "Rosacea and Perioral Dermatitis", 703, 884, "S", null },
                    { 688, 0, 0, "Rosacea following prolonged treatment with a topical steroid", 704, 703, "S", null },
                    { 689, 0, 0, "Rosacea with rosacea conjunctivitis", 705, 703, "S", null },
                    { 690, 0, 0, "Rosacea, severe", 706, 703, "S", null },
                    { 691, 0, 0, "Rubella", 707, 833, "S", null },
                    { 692, 0, 0, "Sarcoidosis", 708, 116, "S", null },
                    { 693, 0, 0, "Scabies", 709, 738, "S", null },
                    { 694, 0, 0, "Scabies - burrow and mite", 710, 738, "S", null },
                    { 695, 0, 0, "Scabies from a fox", 711, 738, "S", null },
                    { 684, 0, 0, "Ring wart", 700, 835, "S", null },
                    { 781, 0, 0, "Tinea of the right foot (Trichophyton rubrum) and vesicular id on the sides of the fingers of both hands", 800, 249, "S", null },
                    { 725, 0, 0, "Solar urticaria", 742, 817, "S", null },
                    { 727, 0, 0, "Spider Naevus", 744, 823, "S", null },
                    { 756, 0, 0, "Swimming pool granuloma", 775, 116, "S", null },
                    { 757, 0, 0, "Sycosis Barbae", 776, 116, "S", null }
                });

            migrationBuilder.InsertData(
                table: "DEFDiagnoses",
                columns: new[] { "id", "category", "favorite", "fullname", "origin_id", "parent_id", "risk", "shortname" },
                values: new object[,]
                {
                    { 758, 0, 0, "Syringomas", 777, 282, "S", null },
                    { 759, 0, 0, "Systemic lupus erythematosus", 778, 464, "S", null },
                    { 760, 0, 0, "Telangiectasis of the nose", 779, 823, "S", null },
                    { 761, 0, 0, "Telogen hair loss - with regrowth", 780, 83, "S", null },
                    { 762, 0, 0, "Thrombosis in a vessel in the arm", 781, 823, "S", null },
                    { 763, -1, 0, "Tinea", 782, 162, "S", null },
                    { 764, 0, 0, "Tinea and onychomycosis of the right foot (Trichophyton rubrum)", 783, 249, "S", null },
                    { 765, 0, 0, "Tinea capitis", 784, 782, "S", null },
                    { 766, 0, 0, "Tinea capitis caused by Microsporum canis", 785, 249, "S", null },
                    { 755, 0, 0, "Superficial white onychomycosis", 774, 249, "S", null },
                    { 767, 0, 0, "Tinea capitis caused by Trichophyton violaceum", 786, 249, "S", null },
                    { 769, 0, 0, "Tinea corporis", 788, 782, "S", null },
                    { 770, 0, 0, "Tinea cruris", 789, 782, "S", null },
                    { 771, 0, 0, "Tinea cruris (Trichophyton rubrum)", 790, 249, "S", null },
                    { 772, 0, 0, "Tinea of a finger (Trichophyton rubrum)", 791, 249, "S", null },
                    { 773, 0, 0, "Tinea of both feet (Trichophyton rubrum)", 792, 249, "S", null },
                    { 774, 0, 0, "Tinea of both feet (Trichophyton rubrum). Moccasin feet", 793, 249, "S", null },
                    { 775, 0, 0, "Tinea of the hand caused by Trichophyton verrucosum", 794, 249, "S", null },
                    { 776, 0, 0, "Tinea of the left hand (Trichophyton mentagrophytes)", 795, 249, "S", null },
                    { 777, 0, 0, "Tinea of the left hand (Trichophyton rubrum)", 796, 249, "S", null },
                    { 778, 0, 0, "Tinea of the lower leg (Trichophyton rubrum)", 797, 249, "S", null },
                    { 779, 0, 0, "Tinea of the right foot (Trichophyton mentagrophytes)", 798, 249, "S", null },
                    { 768, 0, 0, "Tinea caused by Microsporum canis", 787, 249, "S", null },
                    { 726, 0, 0, "Spider angioma", 743, 823, "S", null },
                    { 754, 0, 1, "Superficial spreading melanoma", 772, 479, "MR", null },
                    { 752, 0, 0, "Sun-induced elastosis", 769, 688, "S", null },
                    { 728, 0, 0, "Spider nevi in liver disease", 745, 739, "S", null },
                    { 729, 0, 0, "Spit's Nevus", 746, 601, "S", null },
                    { 730, 0, 1, "Spitz's Nevus", 747, -1, "S", null },
                    { 731, 0, 0, "Squamous Cell Carcinoma", 748, 885, "AR", null },
                    { 732, 0, 0, "Squamous cell carcinoma - retroauricular", 749, 557, "AR", null },
                    { 733, 0, 0, "Squamous cell carcinoma on the hand", 750, 557, "AR", null },
                    { 734, 0, 0, "Squamous cell carcinoma on the lower lip", 751, 557, "AR", null },
                    { 735, 0, 0, "Squamous cell carcinoma on the penis", 752, 557, "AR", null },
                    { 736, 0, 0, "Staphylococcal impetigo", 753, 116, "S", null },
                    { 737, 0, 0, "Staphylococcal scalded skin syndrome", 754, 116, "S", null },
                    { 738, 0, 0, "Staphylococcal scalded skin syndrome in early stage with erythema on the neck", 755, 116, "S", null },
                    { 753, 0, 0, "Superficial Basal cell carcinoma", 771, 118, "AR", null },
                    { 739, -1, 0, "Stasis Eczema", 756, 280, "S", null },
                    { 741, 0, 0, "Stoma dermatitis II", 758, 217, "S", null },
                    { 742, 0, 0, "Stoma dermatitis under the plastic bag", 759, 217, "S", null },
                    { 743, 0, 0, "Stomatitis from analgam in a mercury-sensitive patient", 760, 573, "S", null },
                    { 744, 0, 0, "Stomatitis in a patient sensitive to balsam of Peru", 761, 573, "S", null },
                    { 745, 0, 0, "Striae distensae", 762, 823, "S", null },
                    { 746, 0, 0, "Striae distensae of the axilla", 763, 110, "S", null },
                    { 747, 0, 0, "Striae distensae on the abdomen and a thigh", 764, 110, "S", null },
                    { 748, -1, 0, "Subcutaneous", 765, 136, "", null },
                    { 749, 0, 0, "Subungual haemorrhage (traumatic)", 766, 538, "S", null },
                    { 750, 0, 0, "Subungual hand eczema", 767, 350, "S", null },
                    { 751, 0, 0, "Sunburn with scaling", 768, 688, "AR", null },
                    { 740, 0, 0, "Steroid acne", 757, 884, "S", null },
                    { 446, 0, 0, "Lichenoid, pigmented drug eruption", 453, 266, "S", null },
                    { 612, 0, 0, "Polymorphic light eruption", 628, 688, "S", null },
                    { 444, 0, 0, "Lichenification", 451, 103, "S", null },
                    { 141, 0, 0, "Blue naevus", 141, 902, "S", null },
                    { 142, 0, 0, "Bovine scabies", 143, 738, "S", null },
                    { 143, 0, 0, "Bowenoid papulosis", 144, 885, "AR", null },
                    { 144, 0, 0, "Bowen's disease", 145, 557, "AR", null },
                    { 145, 0, 0, "Bowen's disease mimicking leg ulcer", 146, 557, "AR", null },
                    { 146, 0, 0, "Breast cancer", 147, 228, "AR", null },
                    { 147, 0, 0, "Brittle nails", 148, 531, "S", null },
                    { 148, -1, 0, "Bullous Diseases", 149, 690, "S", null },
                    { 149, 0, 0, "Bullous erysipelas", 150, 116, "S", null },
                    { 150, 0, 0, "Bullous erythema multiforme", 151, 149, "S", null },
                    { 151, 0, 0, "Bullous fleabites", 152, 738, "S", null },
                    { 140, 0, 0, "Black heel", 140, 672, "S", null },
                    { 152, 0, 0, "Bullous impetigo", 153, 116, "S", null },
                    { 154, 0, 0, "Bullous pemphigoid", 155, 149, "S", null },
                    { 155, 0, 0, "Bullous pemphigoid mimicking pompholyx", 156, 149, "S", null },
                    { 156, 0, 0, "Buschke-Löwenstein's disease", 157, 885, "AR", null },
                    { 157, 0, 0, "Calcification in a renal transplant patient", 158, 739, "S", null },
                    { 158, 0, 0, "Callosity", 159, 282, "S", null },
                    { 159, 0, 0, "Cambell de Morgan Spots", 160, 110, "S", null },
                    { 160, 0, 0, "Candida balanitis", 161, 885, "S", null },
                    { 161, -1, 0, "Candidiasis", 162, 380, "S", null },
                    { 162, 0, 0, "Candidiasis Interdigital", 163, 162, "S", null },
                    { 163, 0, 0, "Candidiasis of the axilla", 164, 162, "S", null },
                    { 164, 0, 0, "Candidiasis of the penis", 165, 162, "S", null },
                    { 153, 0, 0, "Bullous lichen planus", 154, 149, "S", null },
                    { 165, 0, 0, "Candidiasis of the vulva", 166, 162, "S", null },
                    { 139, 0, 0, "Black hairy tongue", 139, 573, "S", null },
                    { 137, 0, 0, "Bites of Cheylitiella", 137, 738, "S", null },
                    { 113, 0, 0, "Atrophy of the skin", 113, 110, "S", null },
                    { 114, 0, 1, "Atypical Nevus", 114, -1, "MR", null },
                    { 115, 0, 0, "Baboon syndrome caused by the ingestion of balsams in a person allergic to balsam of Peru", 115, 58, "S", null },
                    { 116, -1, 0, "Bacterial infections", 116, 380, "S", null },
                    { 117, 0, 0, "Balanitis", 117, 116, "S", null },
                    { 118, -1, 0, "Basal Cell Carcinoma", 118, 487, "AR", null },
                    { 119, 0, 0, "Basal cell carcinoma - cystic", 119, 557, "AR", null },
                    { 120, 0, 0, "Basal cell carcinoma - giant on the back", 120, 557, "AR", null },
                    { 121, 0, 0, "Basal cell carcinoma - nodular", 121, 557, "AR", null },
                    { 122, 0, 0, "Basal cell carcinoma - ulcerated", 122, 557, "AR", null },
                    { 123, 0, 0, "Basal cell carcinoma \"dangerous\" location", 123, 557, "AR", null },
                    { 138, 0, 0, "Bites of head lice", 138, 738, "S", null },
                    { 124, 0, 0, "Basal cell carcinoma and intradermal naevus", 124, 557, "AR", null },
                    { 126, 0, 0, "Basal cell carcinoma in sebaceous nevus", 126, 557, "AR", null },
                    { 127, 0, 0, "Basal cell carcinoma mimicking leg ulcer", 127, 557, "AR", null },
                    { 128, 0, 1, "Basal Cell Carcinoma NOS", 128, -1, "AR", null },
                    { 129, 0, 0, "Basal cell carcinoma of the scalp", 129, 557, "AR", null },
                    { 130, 0, 0, "Basal cell carcinoma, large superficial", 130, 557, "AR", null },
                    { 131, 0, 0, "Basal cell carcinoma, pigmented", 131, 557, "AR", null },
                    { 132, 0, 0, "Basal cell carcinoma, pigmented - multiple", 132, 557, "AR", null },
                    { 133, 0, 0, "Becker's naevus", 133, 902, "S", null },
                    { 134, 0, 0, "Behcet's disease", 134, 823, "S", null },
                    { 135, 0, 0, "Benign mucosal pemphigoid", 135, 149, "S", null },
                    { 136, -1, 0, "Benign Tumours", 136, 812, "", null },
                    { 125, 0, 0, "Basal cell carcinoma behind the ear", 125, 557, "AR", null },
                    { 112, 0, 0, "Atrophic lichen planus of the axillary region", 112, 433, "S", null },
                    { 166, 0, 0, "Candidiasis under pendulous breasts", 167, 162, "S", null },
                    { 168, 0, 0, "Caterpillar dermatitis", 169, 217, "S", null },
                    { 197, 0, 0, "Clubbing of the nails", 198, 531, "S", null },
                    { 198, 0, 0, "Cold urticaria", 199, 817, "S", null },
                    { 199, 0, 0, "Cold urticaria reproduced by means of an ice cube", 200, 817, "S", null },
                    { 200, -1, 0, "Collagen Diseases", 201, 209, "S", null },
                    { 201, 0, 1, "Combined Nevus", 202, -1, "AR", null },
                    { 202, 0, 0, "Comedonal acne", 203, 20, "S", null },
                    { 203, 0, 0, "Comedones following irradiation treatment", 204, 884, "S", null },
                    { 204, 0, 0, "Comedones, closed", 205, 20, "S", null },
                    { 205, 0, 0, "Comedones, open", 206, 20, "S", null },
                    { 206, 0, 1, "Compound Nevus", 207, -1, "AR", null },
                    { 207, 0, 0, "Confluent urticarial weals", 208, 817, "S", null },
                    { 196, 0, 0, "Clothing pattern of contact dermatitis", 197, 58, "S", null },
                    { 208, -1, 0, "Congenital and Internal Diseases", 209, -1, "", null },
                    { 210, 0, 0, "Congenital Nevomelanocytic Nevus", 211, 902, "MR", null },
                    { 211, 0, 0, "Congenital Nevomelanocytic Nevus Giant", 212, 902, "MR", null },
                    { 212, 0, 0, "Congenital Nevomelanocytic Nevus Large", 213, 902, "MR", null },
                    { 213, 0, 1, "Congenital Nevus", 214, -1, "AR", null },
                    { 214, 0, 0, "Connective tissue naevus", 215, 239, "S", null },
                    { 215, 0, 0, "Connubial herpes", 216, 834, "S", null },
                    { 216, -1, 0, "Contact dermatitis", 217, 852, "S", null },
                    { 217, 0, 0, "Contact urticaria from latex protein", 218, 817, "S", null },
                    { 218, 0, 0, "Contact urticaria of the hands caused by latex protein after wearing latex gloves for 3 minutes", 219, 349, "S", null },
                    { 219, 0, 0, "Cosmetic acne", 220, 884, "S", null },
                    { 220, 0, 0, "Crab lice and eggs", 221, 738, "S", null },
                    { 209, 0, 0, "Congenital ichthyosiform erythroderma", 210, 375, "S", null },
                    { 167, 0, 0, "Capillary hemangioma (Salmon patch, stork bite)", 168, 354, "S", null },
                    { 195, 0, 0, "Cimicosis", 196, 738, "S", null },
                    { 193, 0, 0, "Chronic, fissured hand eczema", 194, 350, "S", null },
                    { 169, 0, 0, "Cavernous Hemangioma", 170, 354, "S", null },
                    { 170, 0, 0, "Cavernous hemangioma - ulcerated", 171, 354, "S", null },
                    { 171, 0, 0, "Cavernous hemangioma in an infant", 172, 354, "S", null },
                    { 172, 0, 0, "Cavernous hemangioma with subcutaneous involvement", 173, 354, "S", null },
                    { 173, 0, 0, "Cellulitis", 174, 116, "S", null },
                    { 174, 0, 0, "Cellulitis with elephanthiasis of the penis", 175, 116, "S", null },
                    { 175, 0, 0, "Cement ulcerations", 176, 217, "S", null },
                    { 176, 0, 0, "Centroblastic malignant lymphoma", 177, 474, "MR", null },
                    { 177, 0, 0, "Chancroid with bubo in the right groin", 178, 885, "S", null },
                    { 178, 0, 0, "Chapping", 179, 350, "S", null },
                    { 179, 0, 0, "Cheilitis", 180, 217, "S", null },
                    { 194, 0, 0, "Chrysiasis", 195, 266, "S", null },
                    { 180, 0, 0, "Cheilitis caused by isotretinoin", 181, 266, "S", null },
                    { 182, 0, 0, "Cholinergic urticaria", 183, 817, "S", null },
                    { 183, 0, 0, "Cholinergic urticaria with small weals on the upper trunk", 184, 817, "S", null },
                    { 184, 0, 0, "Chondrodermatitis", 185, 823, "S", null },
                    { 185, 0, 0, "Chromate dermatitis from leather in shoes", 186, 58, "S", null },
                    { 186, 0, 0, "Chromate dermatitis from leather in work shoes", 187, 58, "S", null },
                    { 187, 0, 0, "Chromate dermatitis from the contents of a trouser pocket", 188, 58, "S", null },
                    { 188, 0, 0, "Chromate dermatitis on the left wrist from a leather watch strap.", 189, 58, "S", null },
                    { 189, 0, 0, "Chronic paronychion", 190, 530, "S", null },
                    { 190, 0, 0, "Chronic stasis", 191, 823, "S", null },
                    { 191, 0, 0, "Chronic stasis dermatitis", 192, 756, "S", null },
                    { 192, 0, 0, "Chronic Urticaria", 193, 817, "S", null },
                    { 181, 0, 0, "Chiblains", 182, 688, "S", null },
                    { 221, 0, 0, "Creeping eruption", 222, 738, "S", null },
                    { 111, 0, 0, "Atrophic lichen planus", 111, 433, "S", null },
                    { 109, 0, 0, "Atopic Eczema", 109, 280, "S", null },
                    { 29, 0, 0, "Acne rosacea", 28, 703, "S", null },
                    { 30, -1, 0, "Acne Scars", 29, 884, "S", null },
                    { 31, 0, 0, "Acne vulgaris", 30, 20, "S", null },
                    { 32, 0, 0, "Acne vulgaris - Scars", 31, 20, "S", null },
                    { 33, 0, 0, "Acne Vulgaris conglobata", 32, 20, "S", null },
                    { 34, 0, 0, "Acne Vulgaris nodulocystic", 33, 20, "S", null },
                    { 35, 0, 0, "Acne Vulgaris papulopustular", 34, 20, "S", null },
                    { 36, 0, 0, "Acne, mild", 35, 20, "S", null },
                    { 37, 0, 0, "Acne, moderate", 36, 20, "S", null },
                    { 38, 0, 0, "Acne, severe", 37, 20, "S", null },
                    { 39, 0, 0, "Acral infantile pustulosis", 38, 833, "S", null },
                    { 28, 0, 0, "Acne precipitated by camouflage cream", 27, 884, "S", null },
                    { 40, 0, 1, "Acral Lentiginous Melanoma", 39, 479, "MR", null },
                    { 42, 0, 0, "Acrodermatitis Hallopeau", 42, 680, "S", null },
                    { 43, 0, 0, "Actinic keratosis", 43, 282, "AR", null },
                    { 44, 0, 0, "Actinomycosis of the neck", 44, 116, "S", null },
                    { 45, 0, 0, "Acute and chronic hand eczema (vesicular and fissured)", 45, 350, "S", null },
                    { 46, 0, 0, "Acute bullous contact dermatitis from a scabicide", 46, 217, "S", null },
                    { 47, 0, 0, "Acute dermatitis caused by a scabicide", 47, 217, "S", null },
                    { 48, 0, 0, "Acute dermatitis from turpentine", 48, 217, "S", null },
                    { 49, 0, 0, "Acute facial contact dermatitis", 49, 217, "S", null },
                    { 50, 0, 0, "Acute hand eczema", 50, 349, "S", null },
                    { 51, 0, 0, "Acute paronychion", 51, 530, "S", null },
                    { 52, 0, 0, "Acute sunburn", 52, 688, "AR", null },
                    { 41, 0, 0, "Acrodermatitis chronica atrophicans ", 41, 116, "S", null },
                    { 53, 0, 0, "Acute vesicular hand eczema (Pompholyx)", 53, 349, "S", null },
                    { 27, 0, 0, "Acne neonatorum", 26, 20, "S", null },
                    { 25, 0, 0, "Acne fulminans", 24, 20, "S", null },
                    { 1, 0, 0, "Pending", 0, -1, "P", null },
                    { 2, 0, 0, "A Beau groove", 1, 531, "S", null },
                    { 3, 0, 0, "A bullous reaction to insect bites", 2, 149, "S", null },
                    { 4, 0, 0, "A drug eruption caused by amitryptoline", 3, 266, "S", null },
                    { 5, 0, 0, "A drug eruption caused by ampicillin in a patient with mononucleosis", 4, 266, "S", null },
                    { 6, 0, 0, "A drug eruption caused by chloroquine", 5, 266, "S", null },
                    { 7, 0, 0, "A drug eruption caused by chlorpromazine", 6, 266, "S", null },
                    { 8, 0, 0, "A drug eruption caused by gold", 7, 266, "S", null },
                    { 9, 0, 0, "A drug eruption caused by X-ray contrast medium", 8, 266, "S", null },
                    { 10, 0, 0, "A photo drug eruption", 9, 265, "S", null },
                    { 11, 0, 0, "A photo drug eruption caused by quinine", 10, 265, "S", null },
                    { 26, 0, 0, "Acne Inflammatory", 25, 20, "S", null },
                    { 12, 0, 0, "A photo drug eruption caused by thiazide", 11, 265, "S", null },
                    { 14, 0, 0, "A positive patch test to potassium dichromate", 13, 58, "S", null },
                    { 15, 0, 0, "A positive patch test to the perfume-mixture", 14, 58, "S", null },
                    { 16, 0, 0, "A positive prick test to latex protein", 15, 349, "S", null },
                    { 17, 0, 0, "A pustular drug eruption from ampicillin", 16, 266, "S", null },
                    { 18, 0, 0, "A sudden outbreak of atopic dermatitis caused by superantigens from Staphylococcus aureus", 17, 103, "S", null },
                    { 445, 0, 0, "Lichenoid drug eruption caused by quinidine", 452, 266, "S", null },
                    { 20, 0, 0, "Acanthosis Nigricans", 19, 601, "S", null },
                    { 21, -1, 0, "Acne", 20, 884, "S", null },
                    { 22, 0, 0, "Acne excoriée de jeunes filles", 21, 884, "S", null },
                    { 23, 0, 0, "Acne following lithium treatment", 22, 884, "S", null },
                    { 24, 0, 0, "Acne following the use of occlusive ear plugs", 23, 884, "S", null },
                    { 13, 0, 0, "A positive nickel patch test", 12, 58, "S", null },
                    { 110, -1, 0, "Atrophic and dystrophic diseases", 110, 690, "S", null },
                    { 54, 0, 0, "Acute weeping contact dermatitis", 54, 217, "S", null },
                    { 56, 0, 0, "Age-induced hypertrichosis of the eyebrows", 56, 369, "S", null },
                    { 85, 0, 0, "Alopecia universalis", 85, 83, "S", null },
                    { 86, 0, 1, "Amelanotic Melanoma", 86, -1, "MR", null },
                    { 87, 0, 0, "Ammonia napkin dermatitis", 87, 217, "S", null },
                    { 88, 0, 0, "Amyotrophic lateral sclerosis", 88, 739, "S", null },
                    { 89, 0, 0, "An adult with atopic dermatitis. A positive prick test to Pityrosporum ovale is common (head and neck dermatitis)", 89, 103, "S", null },
                    { 90, 0, 0, "An infected fissure on the earlobe - a characteristic feature of atopic dermatitis", 90, 103, "S", null },
                    { 91, 0, 0, "An LE-like syndrome caused by sulphasalazine", 91, 266, "S", null },
                    { 92, 0, 0, "Anetoderma", 92, 110, "S", null },
                    { 93, 0, 1, "Angiokeratoma", 93, 354, "S", null },
                    { 94, 0, 0, "Angiokeratoma of the scrotum", 94, 354, "S", null },
                    { 95, 0, 1, "Angioma NOS", 95, -1, "S", null },
                    { 84, -1, 0, "Alopecia Scarring", 84, 344, "S", null },
                    { 96, 0, 0, "Angioneurotic oedema", 96, 817, "S", null },
                    { 98, 0, 0, "Aphthous stomatitis", 98, 573, "S", null },
                    { 99, 0, 0, "Apocrine hidrocystoma", 99, 282, "S", null },
                    { 100, 0, 0, "Arsenical keratoses", 100, 282, "AR", null },
                    { 101, 0, 0, "Arterial ulcers", 101, 823, "S", null },
                    { 102, 0, 0, "Asymmetric acral viral exanthema", 102, 833, "S", null },
                    { 103, -1, 0, "Atopic Dermatitis", 103, 280, "S", null },
                    { 104, 0, 0, "Atopic Dermatitis Child Type", 104, 103, "S", null },
                    { 105, 0, 0, "Atopic Dermatitis Chronic", 105, 103, "S", null },
                    { 106, 0, 0, "Atopic dermatitis of the cubital fossae", 106, 103, "S", null },
                    { 107, 0, 0, "Atopic dermatitis of the face", 107, 103, "S", null },
                    { 108, 0, 0, "Atopic dermatitis of the upper and lower arm", 108, 103, "S", null },
                    { 97, 0, 0, "Annular lichen planus under the breast", 97, 433, "S", null },
                    { 55, 0, 0, "Adenoma sebaceum", 55, 282, "S", null },
                    { 83, -1, 0, "Alopecia Non-scarring", 83, 344, "S", null },
                    { 81, 0, 0, "Alopecia areata with exclamation mark hairs", 81, 83, "S", null },
                    { 57, 0, 0, "Albinism", 57, 209, "AR", null },
                    { 58, -1, 0, "Allergic Contact Dermatitis", 58, 852, "S", null },
                    { 59, 0, 0, "Allergic contact dermatitis caused by garlic", 59, 58, "S", null },
                    { 60, 0, 0, "Allergic contact dermatitis caused by the preservative imidazolyl urea", 60, 58, "S", null },
                    { 61, 0, 0, "Allergic contact dermatitis from acrylates in a leg prosthesis", 61, 58, "S", null },
                    { 62, 0, 0, "Allergic contact dermatitis from acrylates in a plastic crutch", 62, 58, "S", null },
                    { 63, 0, 0, "Allergic contact dermatitis from fragrance in a cosmetic", 63, 58, "S", null },
                    { 64, 0, 0, "Allergic contact dermatitis from fragrance in a detergent", 64, 58, "S", null },
                    { 65, 0, 0, "Allergic contact dermatitis from mercaptobenzothiazole in rubber-lined shin protectors used for playing soccer", 65, 58, "S", null },
                    { 66, 0, 0, "Allergic contact dermatitis from mercaptobenzothiazole in shoes", 66, 58, "S", null },
                    { 67, 0, 0, "Allergic contact dermatitis from mercaptobenzothiazole in the elastic waistband of an undergarment", 67, 58, "S", null },
                    { 82, 0, 0, "Alopecia following chemotherapy for cancer", 82, 83, "S", null }
                });

            migrationBuilder.InsertData(
                table: "DEFDiagnoses",
                columns: new[] { "id", "category", "favorite", "fullname", "origin_id", "parent_id", "risk", "shortname" },
                values: new object[,]
                {
                    { 68, 0, 0, "Allergic contact dermatitis from parabens in a Unna boot II", 68, 58, "S", null },
                    { 70, 0, 0, "Allergic contact dermatitis from plants in the compositae family IV", 70, 58, "S", null },
                    { 71, 0, 0, "Allergic contact dermatitis from the preservative Kathon CG® (isothiazolinones)", 71, 58, "S", null },
                    { 72, 0, 0, "Allergic contact dermatitis from thiuram in latex gloves", 72, 58, "S", null },
                    { 73, 0, 0, "Allergic contact dermatitis from toluenesulfonyl urea - patch test results", 73, 58, "S", null },
                    { 74, 0, 0, "Allergic contact dermatitis from toluenesulfonyl urea in nail varnish II", 74, 58, "S", null },
                    { 75, 0, 0, "Allergic contact stomatitis caused by the mercury in amalgam dental fillings in a mercury-sensitive person", 75, 58, "S", null },
                    { 76, 0, 0, "Allergic Phytodermatitis", 76, 58, "S", null },
                    { 77, 0, 0, "Allergic vasculitis", 77, 823, "S", null },
                    { 78, 0, 0, "Alopecia areata", 78, 83, "S", null },
                    { 79, 0, 0, "Alopecia areata - extensive", 79, 83, "S", null },
                    { 80, 0, 0, "Alopecia areata in the beard area", 80, 83, "S", null },
                    { 69, 0, 0, "Allergic contact dermatitis from paraphenylene diamine", 69, 58, "S", null },
                    { 222, 0, 0, "Creeping neurotic excoriations", 223, 823, "S", null },
                    { 19, 0, 0, "Abscess/furuncle", 18, 116, "S", null },
                    { 224, 0, 0, "CRST (Calcinosis, Raynaud, Sclerodactyli, Telangiectasia) syndrome", 225, 715, "S", null },
                    { 364, 0, 0, "Hidradenitis Suppurativa", 366, 884, "S", null },
                    { 365, 0, 0, "Hydroa aestivale", 367, 688, "S", null },
                    { 366, 0, 0, "Hyperhidrosis", 368, 263, "S", null },
                    { 367, -1, 0, "Hypertrichosis", 369, 344, "S", null },
                    { 368, 0, 0, "Hypertrichosis following Regaine treatment", 370, 369, "S", null },
                    { 369, 0, 0, "Hypertrichosis following treatment with a potent topical steroid", 371, 369, "S", null },
                    { 370, 0, 0, "Hypertrichosis of the ear, genetically determined", 372, 369, "S", null },
                    { 371, 0, 0, "Hypertrichosis, genetically determined", 373, 369, "S", null },
                    { 372, 0, 0, "Hypertrophic lichen planus", 374, 433, "S", null },
                    { 373, -1, 0, "Ichthyoses", 375, 209, "S", null },
                    { 374, 0, 0, "Ichthyosis Vulgaris", 376, 375, "S", null },
                    { 375, 0, 0, "Impetigo", 377, 116, "S", null },
                    { 376, 0, 0, "Incontinentia pigmenti", 378, 149, "S", null },
                    { 377, 0, 0, "Infarcts", 379, 823, "S", null },
                    { 378, -1, 0, "Infections and Parasites", 380, -1, "S", null },
                    { 380, 0, 0, "Insect bites in a child", 382, 738, "S", null },
                    { 381, 0, 0, "Interdigital bacterial infection", 383, 116, "S", null },
                    { 382, 0, 0, "Intertrigo in the genitofemoral fold of a man", 384, 217, "S", null },
                    { 383, 0, 0, "Intertrigo under the breasts", 385, 217, "S", null },
                    { 384, 0, 0, "Inverse psoriasis", 386, 649, "S", null },
                    { 385, 0, 0, "Irritant contact dermatitis", 387, 217, "S", null },
                    { 386, 0, 0, "Irritant contact dermatitis in a mechanic - caused by oil", 388, 217, "S", null },
                    { 387, 0, 0, "Irritant dermatitis due to licking", 389, 217, "S", null },
                    { 363, 0, 0, "Herpetic Whitlow", 365, 834, "S", null },
                    { 362, 0, 0, "Herpes zoster (shingles)", 364, 363, "S", null },
                    { 361, -1, 0, "Herpes Zoster", 363, 834, "S", null },
                    { 360, 0, 0, "Herpes Simplex Keratitis", 362, 834, "S", null },
                    { 336, 0, 0, "Grandfather's disease. Pressure dermatitis from sitting in the same position for prolonged periods", 338, 217, "S", null },
                    { 337, 0, 0, "Granuloma Annulare", 339, 823, "S", null },
                    { 338, 0, 0, "Granuloma faciale", 340, 474, "S", null },
                    { 339, 0, 0, "Granuloma following BCG vaccination", 341, 116, "S", null },
                    { 340, 0, 0, "Granulomatous rosacea", 342, 703, "S", null },
                    { 341, 0, 0, "Hailey-Hailey disease", 343, 149, "S", null },
                    { 342, -1, 0, "Hair and Scalp", 344, 736, "", null },
                    { 343, 0, 0, "Hairy leukoplakia in an HIV-positive patient", 345, 573, "AR", null },
                    { 344, 0, 0, "Halo naevi", 346, 902, "S", null },
                    { 345, 0, 0, "Hand eczema - eczema craquelée", 347, 350, "S", null },
                    { 346, 0, 0, "Hand-foot-mouth disease", 348, 834, "S", null },
                    { 388, 0, 0, "Irritant dermatitis of the areola mimicking Paget's disease", 390, 217, "S", null },
                    { 347, -1, 0, "Hands - Acute Dermatitis", 349, 852, "S", null },
                    { 349, 0, 0, "Head lice (eggs on the hairs)", 351, 738, "S", null },
                    { 350, 0, 0, "Head lice from one infested person", 352, 738, "S", null },
                    { 351, 0, 0, "Hemangioma of the ulnar aspects of hands and fingers", 353, 354, "S", null },
                    { 352, -1, 0, "Hemangiomas", 354, 136, "S", null },
                    { 353, 0, 0, "Hemorrhagic fleabites", 355, 738, "S", null },
                    { 354, 0, 0, "Hemosiderotic hemangioma", 356, 354, "S", null },
                    { 355, 0, 0, "Henoch-Schönlein's purpura", 357, 672, "S", null },
                    { 356, 0, 0, "Herpes", 358, 834, "S", null },
                    { 357, 0, 0, "Herpes Gestationis", 359, 834, "S", null },
                    { 358, 0, 0, "Herpes Keratitis", 360, 834, "S", null },
                    { 359, 0, 0, "Herpes simplex", 361, 834, "S", null },
                    { 348, -1, 0, "Hands - Chronic Dermatitis", 350, 852, "S", null },
                    { 389, 0, 0, "Irritant dermatitis of the gluteal region mimicking dermatophytosis", 391, 217, "S", null },
                    { 390, 0, 0, "Irritant hand eczema from excessive hand washing", 392, 350, "S", null },
                    { 391, 0, 0, "Irritant hand eczema mimicking dermatophytosis", 393, 217, "S", null },
                    { 420, 0, 0, "Leiomyomas", 424, 239, "S", null },
                    { 421, 0, 0, "Leishmaniasis", 425, 738, "S", null },
                    { 422, -1, 1, "Lentigo Maligna", 426, 601, "MR", null },
                    { 423, 0, 1, "Lentigo Maligna Melanoma", 427, 426, "MR", null },
                    { 424, 0, 0, "Lentigo Melanoma", 428, 426, "MR", null },
                    { 425, 0, 0, "Lichen Nitidus ", 431, 689, "S", null },
                    { 426, 0, 0, "Lichen planopilaris", 432, 84, "S", null },
                    { 427, -1, 0, "Lichen Planus", 433, 689, "S", null },
                    { 428, 0, 0, "Lichen planus of a finger", 434, 433, "S", null },
                    { 429, 0, 0, "Lichen planus of the lower legs", 436, 433, "S", null },
                    { 430, 0, 0, "Lichen planus of the nails", 437, 381, "S", null },
                    { 419, 0, 0, "Langerhans Cell Histiocytosis", 421, 739, "S", null },
                    { 431, 0, 0, "Lichen planus of the oral mucosa", 438, 433, "S", null },
                    { 433, 0, 0, "Lichen planus of the tongue", 440, 573, "S", null },
                    { 434, -1, 0, "Lichen Sclerosus", 441, 689, "S", null },
                    { 435, 0, 0, "Lichen Sclerosus et Atrophicus", 442, 441, "S", null },
                    { 436, 0, 0, "Lichen sclerosus et atrophicus - white spot disease", 443, 823, "S", null },
                    { 437, 0, 0, "Lichen sclerosus et atrophicus isomorphic phenomenon (Koebner phenomenon)", 444, 823, "S", null },
                    { 438, 0, 0, "Lichen sclerosus et atrophicus with squamous cell carcinoma", 445, 823, "AR", null },
                    { 439, 0, 0, "Lichen sclerosus-phimosis", 446, 441, "S", null },
                    { 440, -1, 0, "Lichen Simplex chronicus", 447, 852, "S", null },
                    { 441, 0, 0, "Lichen simplex chronicus of the dorsum of the foot", 448, 447, "S", null },
                    { 442, 0, 0, "Lichen simplex chronicus of the nape of the neck", 449, 447, "S", null },
                    { 443, 0, 0, "Lichen simplex chronicus of the vulva", 450, 447, "S", null },
                    { 432, 0, 0, "Lichen planus of the penis", 439, 433, "S", null },
                    { 335, 0, 0, "Goutytrophi", 337, 739, "S", null },
                    { 418, 0, 0, "Lamellar Ichthyosis", 420, 375, "S", null },
                    { 416, 0, 0, "Kerion of the vulva caused by Trichophyton mentagrophytes", 418, 249, "S", null },
                    { 392, 0, 0, "Ixodes ricinus attached to the skin", 394, 116, "S", null },
                    { 393, 0, 0, "Jadassohn's psoriasiform dermatitis", 395, 720, "S", null },
                    { 394, 0, 0, "Jessner's lymphocytic infiltrations", 396, 474, "S", null },
                    { 395, 0, 0, "Junction naevus", 397, 902, "S", null },
                    { 396, 0, 0, "Junctional Epidermolysis Bullosa", 398, 149, "S", null },
                    { 397, 0, 1, "Junctional Nevus", 399, -1, "S", null },
                    { 398, 0, 0, "Juvenile rheumatoid arthritis", 400, 739, "S", null },
                    { 399, 0, 0, "Juvenile xanthogranuloma", 401, 239, "S", null },
                    { 400, 0, 1, "Kaposi's Sarcoma", 402, 474, "AR", null },
                    { 401, 0, 0, "Keloid", 403, 239, "S", null },
                    { 402, 0, 0, "Keloid scars", 404, 239, "S", null },
                    { 417, 0, 0, "Koilonychia", 419, 531, "S", null },
                    { 403, 0, 0, "Keloidal acne", 405, 884, "S", null },
                    { 405, 0, 0, "Keratocanthoma", 407, 406, "AR", null },
                    { 406, 0, 0, "Keratoderma", 408, 409, "S", null },
                    { 407, -1, 0, "Keratodermas", 409, 209, "S", null },
                    { 408, -1, 0, "Keratosis", 410, 110, "S", null },
                    { 409, 0, 0, "Keratosis Pilaris", 411, 410, "S", null },
                    { 410, 0, 0, "Keratosis Spreading Pigmented", 412, 410, "S", null },
                    { 411, 0, 0, "Keratotic hand eczema", 413, 350, "S", null },
                    { 412, 0, 0, "Kerion of the beard area caused by Trichophyton verrucosum", 414, 249, "S", null },
                    { 413, 0, 0, "Kerion of the hand caused by Trichophyton verrucosum", 415, 249, "S", null },
                    { 414, 0, 0, "Kerion of the right thigh caused by Trichophyton verrucosum", 416, 249, "S", null },
                    { 415, 0, 0, "Kerion of the scalp caused by Trichophyton verrucosum", 417, 249, "S", null },
                    { 404, -1, 0, "Keratoacanthoma", 406, 487, "AR", null },
                    { 334, 0, 0, "Gougerot-Carteaud", 336, 409, "S", null },
                    { 379, -1, 0, "Inflammatory Nail Changes", 381, 539, "S", null },
                    { 332, 0, 0, "Giant pigmented naevus - partly removed", 334, 902, "AR", null },
                    { 253, 0, 0, "Diabetic ulcer", 254, 823, "S", null },
                    { 254, 0, 0, "Diabetic, bullous dermatosis", 255, 823, "S", null },
                    { 255, 0, 0, "Diffuse palmar keratoderma", 257, 409, "S", null },
                    { 256, 0, 0, "Discoid Eczema", 258, 280, "S", null },
                    { 257, 0, 0, "Discoid lupus erythematosus", 259, 464, "S", null },
                    { 258, 0, 0, "Discoid lupus erythematosus on the lips", 260, 464, "S", null },
                    { 259, 0, 0, "Discoid lupus erythematosus on the scalp", 261, 464, "S", null },
                    { 260, -1, 0, "Diseases of the Hair Shaft", 262, 344, "S", null },
                    { 261, -1, 0, "Diseases of the Sweat Glands", 263, 736, "S", null },
                    { 262, -1, 0, "Drug Eruptions", 264, -1, "S", null },
                    { 263, -1, 0, "Drug Induced Photosensitivity", 265, 264, "S", null },
                    { 252, 0, 0, "Diabetic dermopathy with bullae", 253, 739, "S", null },
                    { 264, -1, 0, "Drug Reaction", 266, 264, "S", null },
                    { 266, 0, 0, "Dystrophy of the nail due to subungual exostosis", 268, 532, "S", null },
                    { 267, 0, 0, "Early stasis dermatitis of the right lower leg", 269, 756, "S", null },
                    { 268, 0, 0, "Eccrine hidrocystomas", 270, 282, "S", null },
                    { 269, 0, 0, "Eccrine poroma", 271, 282, "S", null },
                    { 270, 0, 0, "Echthyma", 272, 116, "S", null },
                    { 271, -1, 0, "Eczema Craquelée", 273, 852, "S", null },
                    { 272, 0, 0, "Eczema craquelée of the leg", 274, 273, "S", null },
                    { 273, 0, 0, "Eczema craquelée of the lower leg", 275, 273, "S", null },
                    { 274, 0, 0, "Eczema craquelée of the upper trunk and upper arm", 276, 273, "S", null },
                    { 275, 0, 0, "Eczema herpeticum", 277, 834, "S", null },
                    { 276, 0, 0, "Eczema nails", 278, 350, "S", null },
                    { 265, 0, 1, "Dysplastic Nevus", 267, -1, "MR", null },
                    { 277, 0, 0, "Embolus", 279, 116, "S", null },
                    { 251, 0, 0, "Diabetic dermopathy", 252, 739, "S", null },
                    { 249, 0, 0, "Dermatophytosis caused by Trichophyton tonsurans", 250, 249, "S", null },
                    { 225, 0, 0, "Cutaneous horn caused by a squamous cell carcinoma", 226, 557, "AR", null },
                    { 226, 0, 0, "Cutaneous horn caused by actinic keratosis", 227, 282, "AR", null },
                    { 227, -1, 0, "Cutaneous Metastases", 228, 812, "AR", null },
                    { 228, 0, 0, "Cutaneous Vasculitis", 229, 823, "S", null },
                    { 229, 0, 0, "Cutis Verticis Gyrata", 230, 344, "S", null },
                    { 230, 0, 0, "Cylindroma", 231, 282, "S", null },
                    { 231, 0, 0, "Cystic acne", 232, 20, "S", null },
                    { 232, 0, 0, "Cysts associated with severe acne", 233, 20, "S", null },
                    { 333, 0, 0, "Gingivitis caused by acitretin", 335, 266, "S", null },
                    { 234, 0, 0, "Darier's disease of the nails", 235, 381, "S", null },
                    { 235, -1, 0, "Depigmentation of Hair", 236, 344, "S", null },
                    { 250, 0, 0, "Dermatosis papulosa nigra", 251, 282, "S", null },
                    { 236, 0, 0, "Depression of the nail due to a myxoid cyst", 237, 532, "S", null },
                    { 238, -1, 0, "Dermal Tumours", 239, 136, "", null },
                    { 239, -1, 0, "Dermatitis", 240, -1, "S", null },
                    { 240, 0, 0, "Dermatitis herpetiformis", 241, 149, "S", null },
                    { 241, 0, 0, "Dermatitis papulosa faciei", 242, 703, "S", null },
                    { 242, 0, 0, "Dermatitis plantaris sicca", 243, 103, "S", null },
                    { 243, 0, 0, "Dermatofibroma", 244, 136, "S", null },
                    { 244, 0, 0, "Dermatofibroma - dimple sign", 245, 239, "S", null },
                    { 245, 0, 0, "Dermatofibrosarcoma protuberans", 246, 474, "AR", null },
                    { 246, 0, 0, "Dermatomyositis", 247, 209, "S", null },
                    { 247, 0, 0, "Dermatophytid caused by Trichophyton rubrum", 248, 350, "S", null },
                    { 248, -1, 0, "Dermatophytoses", 249, 162, "S", null },
                    { 237, 0, 1, "Dermal Nevus", 238, -1, "S", null },
                    { 278, -1, 0, "Endogenous", 280, 240, "", null },
                    { 233, 0, 0, "Darier's disease", 234, 409, "S", null },
                    { 223, 0, 0, "Crohn's disease", 224, 739, "S", null },
                    { 308, 0, 0, "Farmyard pox (milker's nodule with erythema multiforme)", 310, 834, "S", null },
                    { 309, 0, 0, "Farmyard pox (milker's nodule)", 311, 834, "S", null },
                    { 310, 0, 0, "Farmyard pox (orf)", 312, 834, "S", null },
                    { 311, 0, 0, "Fat necrosis following pancreatic disease", 313, 739, "S", null },
                    { 312, 0, 0, "Fibroepithelioma (Pinkus)", 314, 557, "AR", null },
                    { 313, 0, 0, "Fibroma of the tongue", 315, 573, "S", null },
                    { 314, 0, 0, "Filiform wart", 316, 835, "S", null },
                    { 315, 0, 0, "Fixed drug eruption", 317, 266, "S", null },
                    { 316, 0, 0, "Fleabites", 318, 738, "S", null },
                    { 317, 0, 0, "Fleabites (from bird fleas)", 319, 738, "S", null },
                    { 318, 0, 0, "Fleabites with secondary impetigo", 320, 738, "S", null },
                    { 307, 0, 0, "Farmyard pox - Lesions on an udder", 309, 834, "S", null },
                    { 319, 0, 0, "Folliculitis caused by Staphylococcus aureus", 321, 116, "S", null },
                    { 321, 0, 0, "Fox-Fordyce disease", 323, 263, "S", null },
                    { 322, 0, 0, "Freckles", 324, 902, "S", null },
                    { 323, 0, 0, "Freckles induced by tanning beds", 325, 902, "AR", null },
                    { 324, 0, 0, "Frostbite", 326, 688, "S", null },
                    { 325, 0, 0, "Frostbite of the ear of a paper boy", 327, 688, "S", null },
                    { 326, 0, 0, "Gangrene", 328, 823, "S", null },
                    { 328, 0, 0, "Generalised Lichen Planus", 330, 433, "S", null },
                    { 329, 0, 0, "Genital herpes", 331, 834, "S", null },
                    { 330, 0, 0, "Genital warts", 332, 885, "AR", null },
                    { 331, 0, 0, "Geographic tongue", 333, 573, "S", null },
                    { 279, 0, 0, "Eosinophilic granuloma", 281, 739, "S", null },
                    { 320, 0, 0, "Folliculitis decalvans", 322, 84, "S", null },
                    { 306, 0, 0, "Factitial paronychion", 308, 808, "S", null },
                    { 327, 0, 0, "Generalised Atrophic Benign Epidermolysis Bullosa", 329, 149, "S", null },
                    { 304, 0, 0, "Excoriations caused by an analgesic", 306, 266, "S", null },
                    { 305, 0, 0, "Factitial dermatosis", 307, 823, "S", null },
                    { 281, 0, 0, "Epidermal naevus mimicking genital warts", 283, 282, "AR", null },
                    { 282, 0, 0, "Epidermolysis bullosa simplex Weber-Cockayne type", 284, 149, "S", null },
                    { 280, -1, 0, "Epidermal", 282, 136, "", null },
                    { 284, 0, 0, "Eruptive syringomas", 286, 282, "S", null },
                    { 285, 0, 0, "Eruptive xanthomas", 287, 739, "S", null },
                    { 286, 0, 0, "Erysipelas", 288, 116, "S", null },
                    { 287, 0, 0, "Erysipelas of the face", 289, 116, "S", null },
                    { 288, 0, 0, "Erysipelas of the forearm", 290, 116, "S", null },
                    { 289, 0, 0, "Erysipeloid", 291, 116, "S", null },
                    { 290, 0, 0, "Erythema chronicum migrans", 292, 116, "S", null },
                    { 291, 0, 0, "Erythema chronicum migrans - early stage", 293, 116, "S", null },
                    { 283, 0, 0, "Epidermolysis bullosa simplex Weber-Cockayne type in a mother and her child", 285, 149, "S", null },
                    { 293, -1, 0, "Erythema Multiforme", 295, 689, "S", null },
                    { 292, 0, 0, "Erythema infectiosum", 294, 833, "S", null },
                    { 302, 0, 0, "Erythrasma", 304, 116, "S", null },
                    { 300, 0, 0, "Erythema Nodosum", 302, 295, "S", null },
                    { 299, 0, 0, "Erythema multiforme secondary to herpes simplex", 301, 295, "S", null },
                    { 298, 0, 0, "Erythema Multiforme Major", 300, 295, "S", null },
                    { 301, 0, 0, "Erythoderma caused by ampicillin", 303, 266, "S", null },
                    { 296, 0, 0, "Erythema multiforme and herpes simplex which precipitated the eruption", 298, 295, "S", null },
                    { 295, 0, 0, "Erythema multiforme (Stevens-Johnson syndrome)", 297, 295, "S", null },
                    { 294, 0, 0, "Erythema multiforme - widespread", 296, 295, "S", null },
                    { 297, 0, 0, "Erythema multiforme in sun-exposed areas following a herpes simplex infection of the lip", 299, 295, "S", null },
                    { 303, 0, 0, "Erythrokeratodermia variabilis", 305, 409, "S", null }
                });

            migrationBuilder.InsertData(
                table: "DEFLocalTxt",
                columns: new[] { "id", "TxtLokal", "TxtPos" },
                values: new object[,]
                {
                    { 120, "forth toe, left", 20125 },
                    { 119, "third toe, left", 20124 },
                    { 127, "second toe, right", 20132 },
                    { 121, "little toe, left", 20126 },
                    { 122, "left dorsum, lateral", 20127 },
                    { 123, "left dorsum, medial", 20128 },
                    { 124, "right sole", 20129 },
                    { 125, "right dorsum", 20130 },
                    { 126, "great toe, right", 20131 },
                    { 132, "right dorsum, medial", 20137 },
                    { 129, "forth toe, right", 20134 },
                    { 130, "little toe, right", 20135 },
                    { 131, "right dorsum, lateral", 20136 },
                    { 133, "back of the head and neck", 30001 },
                    { 134, "buttocks, left", 30002 },
                    { 135, "buttocks, right", 30003 },
                    { 136, "face and neck", 30004 },
                    { 137, "front face and neck", 30005 },
                    { 138, "left abdomen", 30006 },
                    { 128, "third toe, right", 20133 },
                    { 118, "second toe, left", 20123 },
                    { 106, "left third finger", 20111 },
                    { 116, "left dorsum", 20121 },
                    { 96, "orbital region, right", 20101 },
                    { 139, "left dorsum", 30007 },
                    { 97, "right eyelid, upper", 20102 },
                    { 98, "right eyelid, lower", 20103 },
                    { 99, "right cheek", 20104 },
                    { 100, "right ear", 20105 },
                    { 101, "left palm", 20106 },
                    { 102, "left back of the hand", 20107 },
                    { 103, "left thumb", 20108 },
                    { 117, "great toe, left", 20122 },
                    { 104, "left first finger", 20109 },
                    { 107, "left fourth finger", 20112 },
                    { 108, "right palm", 20113 },
                    { 109, "right back of the hand", 20114 },
                    { 110, "right thumb", 20115 },
                    { 111, "right first finger", 20116 },
                    { 112, "right second finger", 20117 },
                    { 113, "right third finger", 20118 },
                    { 114, "right fourth finger", 20119 },
                    { 115, "left sole", 20120 },
                    { 105, "left second finger", 20110 },
                    { 140, "left back of the hand", 30008 },
                    { 167, "right chest", 30035 },
                    { 142, "left chest", 30010 },
                    { 168, "right face and neck", 30036 },
                    { 169, "right flank", 30037 },
                    { 170, "right foot", 30038 },
                    { 171, "right foot, lateral", 30039 },
                    { 172, "right hand", 30040 },
                    { 173, "right lower arm", 30041 },
                    { 174, "right lower arm, anterior", 30042 },
                    { 175, "right lower arm, medial", 30043 },
                    { 176, "right lower back", 30044 },
                    { 166, "right calf, lateral", 30034 },
                    { 177, "right lower leg", 30045 },
                    { 179, "right palm", 30047 },
                    { 180, "left sole", 30048 },
                    { 181, "right thigh and hip", 30049 },
                    { 182, "right upper arm", 30050 },
                    { 183, "right upper arm, anterior", 30051 },
                    { 184, "right upper arm, medial", 30052 },
                    { 185, "right upper back", 30053 },
                    { 186, "right upper leg", 30054 },
                    { 95, "scalp", 20099 },
                    { 178, "right lower leg, medial", 30046 },
                    { 141, "left calf, lateral", 30009 },
                    { 165, "right back of the hand", 30033 }
                });

            migrationBuilder.InsertData(
                table: "DEFLocalTxt",
                columns: new[] { "id", "TxtLokal", "TxtPos" },
                values: new object[,]
                {
                    { 163, "right abdomen", 30031 },
                    { 143, "left face and neck", 30011 },
                    { 144, "left flank", 30012 },
                    { 145, "left foot", 30013 },
                    { 146, "left foot, lateral", 30014 },
                    { 147, "left hand", 30015 },
                    { 148, "left lower arm", 30016 },
                    { 149, "left lower arm, anterior", 30017 },
                    { 150, "left lower arm, medial", 30018 },
                    { 151, "left lower back", 30019 },
                    { 164, "right dorsum", 30032 },
                    { 152, "left lower leg", 30020 },
                    { 154, "left palm", 30022 },
                    { 155, "right sole", 30023 },
                    { 156, "left thigh and hip", 30024 },
                    { 157, "left upper arm", 30025 },
                    { 158, "left upper arm, anterior", 30026 },
                    { 159, "left upper arm, medial", 30027 },
                    { 160, "left upper back", 30028 },
                    { 161, "left upper leg", 30029 },
                    { 162, "left upper leg, medial", 30030 },
                    { 153, "left lower leg, medial", 30021 },
                    { 187, "right upper leg, medial", 30055 },
                    { 94, "chin", 20098 },
                    { 92, "lower lip", 20096 },
                    { 25, "right lower leg, anterior", 20024 },
                    { 26, "left lower leg, anterior", 20025 },
                    { 27, "right foot", 20026 },
                    { 28, "left foot", 20027 },
                    { 29, "genital spot", 20028 },
                    { 30, "supraclavicular, right", 20029 },
                    { 31, "supraclavicular, left", 20030 },
                    { 32, "right hip", 20031 },
                    { 33, "left hip", 20032 },
                    { 34, "right elbow", 20035 },
                    { 35, "left elbow", 20036 },
                    { 36, "scapular region, right", 20037 },
                    { 37, "scapular region, left", 20038 },
                    { 38, "suprascapular region, right", 20039 },
                    { 39, "suprascapular region, left", 20040 },
                    { 40, "paravertebral, thoracic, right", 20041 },
                    { 41, "paravertebral, thoracic, left", 20042 },
                    { 42, "paravertebral, lumbar, right", 20043 },
                    { 43, "paravertebral, lumbar, left", 20044 },
                    { 24, "left knee", 20023 },
                    { 23, "right knee", 20022 },
                    { 21, "right thigh, anterior", 20020 },
                    { 20, "pubic region", 20019 },
                    { 93, "oral region", 20097 },
                    { 1, "head", 20000 },
                    { 2, "cervical, right", 20001 },
                    { 3, "cervical, left", 20002 },
                    { 4, "thoracic, right", 20003 },
                    { 5, "thoracic, left", 20004 },
                    { 6, "right shoulder", 20005 },
                    { 7, "left shoulder", 20006 },
                    { 8, "right upper arm", 20007 },
                    { 44, "thorax, dorsolateral, right", 20045 },
                    { 9, "left upper arm", 20008 },
                    { 11, "left lower arm", 20010 },
                    { 12, "right hand", 20011 },
                    { 13, "left hand", 20012 },
                    { 14, "right epigastric region", 20013 },
                    { 15, "left epigastric region", 20014 },
                    { 16, "right lower abdomen", 20015 },
                    { 17, "left lower abdomen", 20016 },
                    { 18, "right groin", 20017 },
                    { 19, "left groin", 20018 },
                    { 10, "right lower arm", 20009 },
                    { 45, "thorax, dorsolateral, left", 20046 },
                    { 22, "left thigh, anterior", 20021 },
                    { 47, "left thigh, posterior", 20048 },
                    { 72, "right lower leg, lateral", 20075 },
                    { 73, "right thigh, medial", 20076 },
                    { 74, "right lower leg, medial", 20077 },
                    { 75, "left thigh, medial", 20078 },
                    { 76, "left lower leg, medial", 20079 },
                    { 77, "temporal, right", 20080 },
                    { 78, "temporal, left", 20081 },
                    { 79, "neck, right", 20082 },
                    { 81, "retroauricular, right", 20084 },
                    { 71, "right thigh, lateral", 20074 },
                    { 82, "retroauricular, left", 20085 },
                    { 84, "orbital region, left", 20088 },
                    { 85, "left eyelid, upper", 20089 },
                    { 86, "left eyelid, lower", 20090 },
                    { 87, "left cheek", 20091 },
                    { 88, "left ear", 20092 },
                    { 89, "front", 20093 },
                    { 90, "nose", 20094 },
                    { 46, "right thigh, posterior", 20047 },
                    { 91, "upper lip", 20095 },
                    { 83, "occipital", 20086 },
                    { 70, "right ankle", 20073 },
                    { 80, "neck, left", 20083 },
                    { 69, "buttocks, right", 20072 },
                    { 49, "right heel", 20050 },
                    { 50, "left heel", 20051 },
                    { 51, "left lower leg, posterior", 20052 },
                    { 52, "right upper arm, medial", 20053 },
                    { 53, "right lower arm, medial", 20054 },
                    { 54, "left upper arm, anterior", 20055 },
                    { 56, "left upper arm, medial", 20058 },
                    { 57, "left lower arm, medial", 20059 },
                    { 58, "left popliteal cavity", 20060 },
                    { 59, "left flank", 20061 },
                    { 55, "left lower arm, anterior", 20057 },
                    { 60, "buttocks, left", 20062 },
                    { 68, "right flank", 20071 },
                    { 67, "right popliteal cavity", 20070 },
                    { 66, "right lower arm, anterior", 20069 },
                    { 65, "right upper arm, anterior", 20067 },
                    { 48, "right lower leg, posterior", 20049 },
                    { 63, "left lower leg, lateral", 20065 },
                    { 62, "left thigh, lateral", 20064 },
                    { 61, "left ankle", 20063 },
                    { 64, "back", 20066 }
                });

            migrationBuilder.InsertData(
                table: "DEFMakroLokal",
                columns: new[] { "id", "Area", "Count", "Hotspot", "Jumppos", "PosMann", "PosX1", "PosX2", "PosY1", "PosY2", "TxtLokal", "TxtMann", "b", "g", "r" },
                values: new object[,]
                {
                    { 65, (byte)1, 1182, (byte)0, (byte)0, (byte)5, 81, 116, 36, 80, 30036, "lateral right", (byte)0, (byte)0, (byte)225 },
                    { 74, (byte)1, 446, (byte)0, (byte)0, (byte)6, 89, 133, 285, 301, 30013, "medial right", (byte)0, (byte)0, (byte)160 },
                    { 72, (byte)1, 377, (byte)0, (byte)0, (byte)6, 95, 113, 118, 167, 30006, "medial right", (byte)0, (byte)120, (byte)80 },
                    { 71, (byte)1, 1161, (byte)0, (byte)0, (byte)6, 73, 106, 35, 86, 30004, "medial right", (byte)0, (byte)0, (byte)225 },
                    { 70, (byte)1, 700, (byte)0, (byte)0, (byte)5, 80, 123, 72, 100, 30051, "lateral right", (byte)220, (byte)120, (byte)40 },
                    { 69, (byte)1, 2268, (byte)0, (byte)0, (byte)5, 74, 114, 146, 229, 30049, "lateral right", (byte)0, (byte)200, (byte)240 },
                    { 68, (byte)1, 433, (byte)0, (byte)0, (byte)5, 114, 131, 44, 80, 30042, "lateral right", (byte)220, (byte)40, (byte)40 },
                    { 67, (byte)1, 484, (byte)0, (byte)0, (byte)5, 71, 117, 285, 300, 30039, "lateral right", (byte)0, (byte)240, (byte)120 },
                    { 66, (byte)1, 1810, (byte)0, (byte)0, (byte)5, 75, 115, 92, 145, 30037, "lateral right", (byte)0, (byte)80, (byte)200 },
                    { 73, (byte)1, 471, (byte)0, (byte)0, (byte)6, 96, 114, 78, 117, 30010, "medial right", (byte)0, (byte)200, (byte)0 },
                    { 55, (byte)1, 212, (byte)0, (byte)0, (byte)4, 110, 132, 287, 302, 30038, "dorsal", (byte)0, (byte)240, (byte)120 },
                    { 62, (byte)1, 1075, (byte)0, (byte)0, (byte)4, 107, 133, 173, 220, 30054, "dorsal", (byte)0, (byte)240, (byte)200 },
                    { 61, (byte)1, 1150, (byte)0, (byte)0, (byte)4, 105, 137, 60, 105, 30053, "dorsal", (byte)0, (byte)120, (byte)160 },
                    { 60, (byte)1, 682, (byte)0, (byte)0, (byte)4, 134, 151, 68, 117, 30050, "dorsal", (byte)0, (byte)40, (byte)40 },
                    { 59, (byte)1, 1097, (byte)0, (byte)0, (byte)4, 110, 130, 221, 286, 30045, "dorsal", (byte)0, (byte)120, (byte)240 },
                    { 58, (byte)1, 726, (byte)0, (byte)0, (byte)4, 105, 130, 99, 132, 30044, "dorsal", (byte)0, (byte)200, (byte)160 },
                    { 57, (byte)1, 468, (byte)0, (byte)0, (byte)4, 139, 153, 118, 157, 30041, "dorsal", (byte)0, (byte)120, (byte)40 },
                    { 56, (byte)1, 169, (byte)0, (byte)0, (byte)4, 139, 153, 158, 188, 30040, "dorsal", (byte)0, (byte)200, (byte)40 },
                    { 53, (byte)1, 1150, (byte)0, (byte)0, (byte)4, 72, 104, 60, 105, 30028, "dorsal", (byte)0, (byte)160, (byte)160 },
                    { 54, (byte)1, 1075, (byte)0, (byte)0, (byte)4, 76, 102, 173, 220, 30029, "dorsal", (byte)0, (byte)0, (byte)240 },
                    { 75, (byte)1, 486, (byte)0, (byte)0, (byte)6, 132, 150, 39, 78, 30018, "medial right", (byte)225, (byte)165, (byte)45 },
                    { 63, (byte)1, 323, (byte)0, (byte)0, (byte)5, 122, 140, 17, 43, 30033, "lateral right", (byte)40, (byte)120, (byte)0 },
                    { 76, (byte)1, 974, (byte)0, (byte)0, (byte)6, 89, 111, 230, 284, 30021, "medial right", (byte)85, (byte)5, (byte)5 },
                    { 98, (byte)1, 5391, (byte)0, (byte)0, (byte)9, 1, 103, 161, 317, 30023, "Foot", (byte)80, (byte)200, (byte)0 },
                    { 78, (byte)1, 509, (byte)0, (byte)0, (byte)6, 108, 143, 72, 98, 30027, "medial right", (byte)225, (byte)85, (byte)45 },
                    { 52, (byte)1, 682, (byte)0, (byte)0, (byte)4, 58, 75, 68, 117, 30025, "dorsal", (byte)0, (byte)80, (byte)40 },
                    { 100, (byte)1, 5391, (byte)0, (byte)0, (byte)9, 107, 210, 161, 317, 30048, "Foot", (byte)40, (byte)200, (byte)0 },
                    { 99, (byte)1, 5424, (byte)0, (byte)0, (byte)9, 107, 210, 1, 157, 30032, "Foot", (byte)40, (byte)240, (byte)0 },
                    { 97, (byte)1, 5424, (byte)0, (byte)0, (byte)9, 1, 103, 1, 157, 30007, "Foot", (byte)80, (byte)240, (byte)0 },
                    { 96, (byte)1, 4520, (byte)0, (byte)0, (byte)8, 107, 210, 161, 317, 30047, "Hand", (byte)200, (byte)80, (byte)0 },
                    { 95, (byte)1, 4621, (byte)0, (byte)0, (byte)8, 107, 210, 1, 157, 30033, "Hand", (byte)40, (byte)120, (byte)0 },
                    { 94, (byte)1, 4520, (byte)0, (byte)0, (byte)8, 1, 103, 161, 317, 30022, "Hand", (byte)240, (byte)80, (byte)0 },
                    { 93, (byte)1, 4621, (byte)0, (byte)0, (byte)8, 1, 103, 1, 157, 30008, "Hand", (byte)80, (byte)120, (byte)0 },
                    { 92, (byte)1, 6843, (byte)0, (byte)0, (byte)7, 1, 103, 161, 317, 30036, "Head", (byte)0, (byte)0, (byte)225 },
                    { 91, (byte)1, 6843, (byte)0, (byte)0, (byte)7, 107, 210, 1, 157, 30011, "Head", (byte)0, (byte)0, (byte)235 },
                    { 77, (byte)1, 293, (byte)0, (byte)0, (byte)6, 140, 159, 16, 43, 30022, "medial right", (byte)240, (byte)80, (byte)0 },
                    { 90, (byte)1, 5202, (byte)0, (byte)0, (byte)7, 1, 103, 1, 157, 30005, "Head", (byte)0, (byte)0, (byte)245 },
                    { 88, (byte)1, 1496, (byte)0, (byte)0, (byte)6, 60, 94, 152, 231, 30054, "medial right", (byte)0, (byte)200, (byte)240 },
                    { 87, (byte)1, 849, (byte)0, (byte)0, (byte)6, 52, 75, 83, 134, 30050, "medial right", (byte)220, (byte)120, (byte)40 },
                    { 86, (byte)1, 848, (byte)0, (byte)0, (byte)6, 53, 75, 228, 284, 30045, "medial right", (byte)40, (byte)0, (byte)0 },
                    { 85, (byte)1, 452, (byte)0, (byte)0, (byte)6, 53, 68, 135, 168, 30041, "medial right", (byte)220, (byte)40, (byte)40 },
                    { 84, (byte)1, 339, (byte)0, (byte)0, (byte)6, 53, 83, 285, 301, 30038, "medial right", (byte)0, (byte)240, (byte)120 },
                    { 83, (byte)1, 476, (byte)0, (byte)0, (byte)6, 68, 79, 97, 151, 30037, "medial right", (byte)0, (byte)80, (byte)200 },
                    { 82, (byte)1, 981, (byte)0, (byte)0, (byte)6, 64, 102, 76, 121, 30035, "medial right", (byte)0, (byte)160, (byte)0 },
                    { 81, (byte)1, 275, (byte)0, (byte)0, (byte)6, 58, 75, 169, 196, 30033, "medial right", (byte)40, (byte)120, (byte)0 },
                    { 80, (byte)1, 951, (byte)0, (byte)0, (byte)6, 78, 102, 118, 167, 30031, "medial right", (byte)0, (byte)80, (byte)80 },
                    { 79, (byte)1, 1366, (byte)0, (byte)0, (byte)6, 87, 112, 156, 229, 30030, "medial right", (byte)5, (byte)245, (byte)245 },
                    { 89, (byte)1, 5283, (byte)0, (byte)0, (byte)7, 107, 210, 161, 317, 30001, "Head", (byte)0, (byte)0, (byte)215 },
                    { 51, (byte)1, 1097, (byte)0, (byte)0, (byte)4, 79, 99, 221, 286, 30020, "dorsal", (byte)0, (byte)160, (byte)240 },
                    { 64, (byte)1, 997, (byte)0, (byte)0, (byte)5, 72, 95, 228, 284, 30034, "lateral right", (byte)40, (byte)0, (byte)0 },
                    { 49, (byte)1, 468, (byte)0, (byte)0, (byte)4, 56, 70, 118, 157, 30016, "dorsal", (byte)0, (byte)160, (byte)40 },
                    { 22, (byte)1, 476, (byte)0, (byte)0, (byte)2, 131, 142, 97, 151, 30012, "medial left", (byte)0, (byte)120, (byte)200 },
                    { 21, (byte)1, 981, (byte)0, (byte)0, (byte)2, 108, 146, 76, 121, 30010, "medial left", (byte)0, (byte)200, (byte)0 },
                    { 20, (byte)1, 275, (byte)0, (byte)0, (byte)2, 135, 151, 169, 197, 30008, "medial left", (byte)80, (byte)120, (byte)0 },
                    { 19, (byte)1, 951, (byte)0, (byte)0, (byte)2, 108, 132, 118, 167, 30006, "medial left", (byte)0, (byte)120, (byte)80 },
                    { 18, (byte)1, 1161, (byte)0, (byte)0, (byte)2, 104, 137, 35, 86, 30004, "medial left", (byte)0, (byte)0, (byte)235 },
                    { 17, (byte)1, 1779, (byte)0, (byte)0, (byte)1, 76, 104, 149, 227, 30054, "ventral", (byte)0, (byte)0, (byte)120 },
                    { 16, (byte)1, 647, (byte)0, (byte)0, (byte)1, 58, 75, 67, 114, 30050, "ventral", (byte)0, (byte)40, (byte)40 },
                    { 15, (byte)1, 958, (byte)0, (byte)0, (byte)1, 79, 99, 228, 284, 30045, "ventral", (byte)0, (byte)160, (byte)120 },
                    { 14, (byte)1, 439, (byte)0, (byte)0, (byte)1, 57, 70, 114, 150, 30041, "ventral", (byte)0, (byte)120, (byte)40 },
                    { 13, (byte)1, 220, (byte)0, (byte)0, (byte)1, 57, 70, 151, 188, 30040, "ventral", (byte)0, (byte)200, (byte)40 },
                    { 23, (byte)1, 339, (byte)0, (byte)0, (byte)2, 127, 157, 285, 301, 30013, "medial left", (byte)0, (byte)0, (byte)160 },
                    { 12, (byte)1, 217, (byte)0, (byte)0, (byte)1, 79, 99, 285, 301, 30038, "ventral", (byte)0, (byte)240, (byte)120 },
                    { 9, (byte)1, 1780, (byte)0, (byte)0, (byte)1, 105, 133, 149, 227, 30029, "ventral", (byte)0, (byte)40, (byte)120 },
                    { 8, (byte)1, 636, (byte)0, (byte)0, (byte)1, 134, 151, 67, 113, 30025, "ventral", (byte)0, (byte)80, (byte)40 },
                    { 7, (byte)1, 952, (byte)0, (byte)0, (byte)1, 110, 130, 228, 284, 30020, "ventral", (byte)0, (byte)200, (byte)120 },
                    { 6, (byte)1, 452, (byte)0, (byte)0, (byte)1, 139, 152, 114, 150, 30016, "ventral", (byte)0, (byte)160, (byte)40 },
                    { 5, (byte)1, 218, (byte)0, (byte)0, (byte)1, 139, 152, 151, 188, 30015, "ventral", (byte)0, (byte)240, (byte)40 },
                    { 4, (byte)1, 220, (byte)0, (byte)0, (byte)1, 110, 130, 285, 301, 30013, "ventral", (byte)0, (byte)0, (byte)160 },
                    { 3, (byte)1, 1092, (byte)0, (byte)0, (byte)1, 105, 136, 60, 105, 30010, "ventral", (byte)0, (byte)200, (byte)0 },
                    { 2, (byte)1, 1216, (byte)0, (byte)0, (byte)1, 105, 130, 99, 154, 30006, "ventral", (byte)0, (byte)120, (byte)80 },
                    { 1, (byte)1, 1284, (byte)0, (byte)0, (byte)1, 89, 120, 17, 69, 30005, "ventral", (byte)0, (byte)0, (byte)245 },
                    { 50, (byte)1, 726, (byte)0, (byte)0, (byte)4, 79, 104, 99, 132, 30019, "dorsal", (byte)0, (byte)240, (byte)160 },
                    { 10, (byte)1, 1215, (byte)0, (byte)0, (byte)1, 79, 104, 99, 154, 30031, "ventral", (byte)0, (byte)80, (byte)80 },
                    { 24, (byte)1, 452, (byte)0, (byte)0, (byte)2, 142, 157, 135, 168, 30016, "medial left", (byte)220, (byte)160, (byte)40 },
                    { 11, (byte)1, 1094, (byte)0, (byte)0, (byte)1, 73, 104, 60, 105, 30035, "ventral", (byte)0, (byte)160, (byte)0 },
                    { 26, (byte)1, 849, (byte)0, (byte)0, (byte)2, 135, 158, 83, 134, 30025, "medial left", (byte)220, (byte)80, (byte)40 },
                    { 48, (byte)1, 169, (byte)0, (byte)0, (byte)4, 56, 70, 158, 188, 30015, "dorsal", (byte)0, (byte)240, (byte)40 },
                    { 25, (byte)1, 848, (byte)0, (byte)0, (byte)2, 135, 157, 228, 284, 30020, "medial left", (byte)80, (byte)0, (byte)0 },
                    { 47, (byte)1, 212, (byte)0, (byte)0, (byte)4, 77, 99, 287, 302, 30013, "dorsal", (byte)0, (byte)0, (byte)160 },
                    { 46, (byte)1, 1084, (byte)0, (byte)0, (byte)4, 105, 133, 133, 172, 30003, "dorsal", (byte)0, (byte)0, (byte)20 },
                    { 45, (byte)1, 1084, (byte)0, (byte)0, (byte)4, 76, 104, 133, 172, 30002, "dorsal", (byte)20, (byte)0, (byte)0 },
                    { 44, (byte)1, 1150, (byte)0, (byte)0, (byte)4, 89, 120, 17, 62, 30001, "dorsal", (byte)0, (byte)0, (byte)215 },
                    { 43, (byte)1, 700, (byte)0, (byte)0, (byte)3, 87, 130, 72, 100, 30026, "lateral left", (byte)220, (byte)80, (byte)40 },
                    { 41, (byte)1, 433, (byte)0, (byte)0, (byte)3, 79, 96, 44, 80, 30017, "lateral left", (byte)220, (byte)160, (byte)40 },
                    { 40, (byte)1, 484, (byte)0, (byte)0, (byte)3, 93, 139, 285, 300, 30014, "lateral left", (byte)0, (byte)0, (byte)160 },
                    { 39, (byte)1, 1810, (byte)0, (byte)0, (byte)3, 95, 135, 92, 145, 30012, "lateral left", (byte)0, (byte)120, (byte)200 },
                    { 38, (byte)1, 1182, (byte)0, (byte)0, (byte)3, 94, 129, 36, 80, 30011, "lateral left", (byte)0, (byte)0, (byte)235 },
                    { 42, (byte)1, 2268, (byte)0, (byte)0, (byte)3, 96, 136, 146, 229, 30024, "lateral left", (byte)0, (byte)240, (byte)240 },
                    { 37, (byte)1, 997, (byte)0, (byte)0, (byte)3, 115, 138, 228, 284, 30009, "lateral left", (byte)80, (byte)0, (byte)0 },
                    { 36, (byte)1, 323, (byte)0, (byte)0, (byte)3, 70, 88, 17, 43, 30008, "lateral left", (byte)80, (byte)120, (byte)0 },
                    { 35, (byte)1, 1366, (byte)0, (byte)0, (byte)2, 98, 123, 156, 229, 30055, "medial left", (byte)5, (byte)205, (byte)245 },
                    { 34, (byte)1, 509, (byte)0, (byte)0, (byte)2, 67, 102, 72, 98, 30052, "medial left", (byte)225, (byte)125, (byte)45 },
                    { 33, (byte)1, 293, (byte)0, (byte)0, (byte)2, 51, 70, 16, 43, 30047, "medial left", (byte)200, (byte)80, (byte)0 },
                    { 32, (byte)1, 974, (byte)0, (byte)0, (byte)2, 99, 121, 230, 284, 30046, "medial left", (byte)45, (byte)5, (byte)5 },
                    { 31, (byte)1, 486, (byte)0, (byte)0, (byte)2, 60, 78, 39, 78, 30043, "medial left", (byte)225, (byte)45, (byte)45 },
                    { 30, (byte)1, 446, (byte)0, (byte)0, (byte)2, 77, 121, 285, 301, 30038, "medial left", (byte)0, (byte)240, (byte)120 },
                    { 29, (byte)1, 471, (byte)0, (byte)0, (byte)2, 96, 114, 78, 117, 30035, "medial left", (byte)0, (byte)160, (byte)0 },
                    { 28, (byte)1, 377, (byte)0, (byte)0, (byte)2, 97, 115, 118, 167, 30031, "medial left", (byte)0, (byte)80, (byte)80 },
                    { 27, (byte)1, 1496, (byte)0, (byte)0, (byte)2, 116, 150, 152, 231, 30029, "medial left", (byte)0, (byte)240, (byte)240 }
                });

            migrationBuilder.InsertData(
                table: "DEFMikroLokal",
                columns: new[] { "id", "Hotspot", "Jumppos", "PosMann", "TxtLokal", "TxtMann", "b", "g", "r" },
                values: new object[,]
                {
                    { 164, (byte)0, (byte)0, (byte)6, 20018, "medial right", (byte)0, (byte)200, (byte)80 },
                    { 163, (byte)0, (byte)0, (byte)6, 20017, "medial right", (byte)0, (byte)160, (byte)80 },
                    { 162, (byte)0, (byte)0, (byte)6, 20016, "medial right", (byte)0, (byte)120, (byte)80 },
                    { 161, (byte)0, (byte)0, (byte)6, 20015, "medial right", (byte)0, (byte)80, (byte)80 },
                    { 160, (byte)0, (byte)0, (byte)6, 20014, "medial right", (byte)0, (byte)40, (byte)80 },
                    { 157, (byte)1, (byte)8, (byte)6, 20011, "medial right", (byte)0, (byte)200, (byte)40 },
                    { 158, (byte)1, (byte)8, (byte)6, 20012, "medial right", (byte)0, (byte)240, (byte)40 },
                    { 155, (byte)0, (byte)0, (byte)6, 20004, "medial right", (byte)0, (byte)200, (byte)0 },
                    { 156, (byte)0, (byte)0, (byte)6, 20005, "medial right", (byte)0, (byte)240, (byte)0 },
                    { 165, (byte)0, (byte)0, (byte)6, 20019, "medial right", (byte)0, (byte)240, (byte)80 },
                    { 159, (byte)0, (byte)0, (byte)6, 20013, "medial right", (byte)0, (byte)0, (byte)80 },
                    { 166, (byte)0, (byte)0, (byte)6, 20022, "medial right", (byte)0, (byte)80, (byte)120 },
                    { 178, (byte)0, (byte)0, (byte)6, 20067, "medial right", (byte)220, (byte)120, (byte)40 },
                    { 168, (byte)1, (byte)9, (byte)6, 20026, "medial right", (byte)0, (byte)240, (byte)120 },
                    { 169, (byte)1, (byte)9, (byte)6, 20027, "medial right", (byte)0, (byte)0, (byte)160 },
                    { 170, (byte)0, (byte)0, (byte)6, 20028, "medial right", (byte)60, (byte)60, (byte)0 },
                    { 171, (byte)0, (byte)0, (byte)6, 20029, "medial right", (byte)60, (byte)60, (byte)60 },
                    { 172, (byte)0, (byte)0, (byte)6, 20030, "medial right", (byte)0, (byte)60, (byte)60 },
                    { 173, (byte)0, (byte)0, (byte)6, 20031, "medial right", (byte)180, (byte)0, (byte)0 },
                    { 174, (byte)0, (byte)0, (byte)6, 20058, "medial right", (byte)225, (byte)85, (byte)45 },
                    { 175, (byte)0, (byte)0, (byte)6, 20059, "medial right", (byte)225, (byte)165, (byte)45 },
                    { 176, (byte)0, (byte)0, (byte)6, 20060, "medial right", (byte)0, (byte)80, (byte)240 },
                    { 177, (byte)0, (byte)0, (byte)6, 20063, "medial right", (byte)0, (byte)220, (byte)0 },
                    { 179, (byte)0, (byte)0, (byte)6, 20069, "medial right", (byte)220, (byte)40, (byte)40 },
                    { 180, (byte)0, (byte)0, (byte)6, 20071, "medial right", (byte)0, (byte)80, (byte)200 },
                    { 154, (byte)0, (byte)0, (byte)6, 20003, "medial right", (byte)0, (byte)160, (byte)0 },
                    { 167, (byte)0, (byte)0, (byte)6, 20023, "medial right", (byte)0, (byte)120, (byte)120 }
                });

            migrationBuilder.InsertData(
                table: "DEFMikroLokal",
                columns: new[] { "id", "Hotspot", "Jumppos", "PosMann", "TxtLokal", "TxtMann", "b", "g", "r" },
                values: new object[,]
                {
                    { 153, (byte)0, (byte)0, (byte)6, 20002, "medial right", (byte)0, (byte)120, (byte)0 },
                    { 129, (byte)1, (byte)7, (byte)5, 20000, "lateral right", (byte)0, (byte)40, (byte)0 },
                    { 151, (byte)1, (byte)7, (byte)6, 20000, "medial right", (byte)0, (byte)40, (byte)0 },
                    { 124, (byte)0, (byte)0, (byte)4, 20070, "dorsal", (byte)0, (byte)40, (byte)240 },
                    { 125, (byte)0, (byte)0, (byte)4, 20071, "dorsal", (byte)0, (byte)80, (byte)200 },
                    { 126, (byte)0, (byte)0, (byte)4, 20072, "dorsal", (byte)0, (byte)0, (byte)20 },
                    { 127, (byte)0, (byte)0, (byte)4, 20082, "dorsal", (byte)0, (byte)40, (byte)160 },
                    { 128, (byte)0, (byte)0, (byte)4, 20083, "dorsal", (byte)0, (byte)80, (byte)160 },
                    { 181, (byte)0, (byte)0, (byte)6, 20074, "medial right", (byte)0, (byte)200, (byte)240 },
                    { 130, (byte)0, (byte)0, (byte)5, 20001, "lateral right", (byte)0, (byte)80, (byte)0 },
                    { 131, (byte)0, (byte)0, (byte)5, 20003, "lateral right", (byte)0, (byte)160, (byte)0 },
                    { 132, (byte)0, (byte)0, (byte)5, 20005, "lateral right", (byte)0, (byte)240, (byte)0 },
                    { 133, (byte)1, (byte)8, (byte)5, 20011, "lateral right", (byte)0, (byte)200, (byte)40 },
                    { 134, (byte)0, (byte)0, (byte)5, 20013, "lateral right", (byte)0, (byte)0, (byte)80 },
                    { 135, (byte)0, (byte)0, (byte)5, 20015, "lateral right", (byte)0, (byte)80, (byte)80 },
                    { 136, (byte)0, (byte)0, (byte)5, 20017, "lateral right", (byte)0, (byte)160, (byte)80 },
                    { 137, (byte)0, (byte)0, (byte)5, 20019, "lateral right", (byte)0, (byte)240, (byte)80 },
                    { 138, (byte)0, (byte)0, (byte)5, 20022, "lateral right", (byte)0, (byte)80, (byte)120 },
                    { 139, (byte)1, (byte)9, (byte)5, 20026, "lateral right", (byte)0, (byte)240, (byte)120 },
                    { 140, (byte)0, (byte)0, (byte)5, 20031, "lateral right", (byte)180, (byte)0, (byte)0 },
                    { 141, (byte)0, (byte)0, (byte)5, 20035, "lateral right", (byte)0, (byte)100, (byte)180 },
                    { 142, (byte)1, (byte)0, (byte)5, 20066, "lateral right", (byte)0, (byte)0, (byte)100 },
                    { 143, (byte)0, (byte)0, (byte)5, 20067, "lateral right", (byte)220, (byte)120, (byte)40 },
                    { 144, (byte)0, (byte)0, (byte)5, 20069, "lateral right", (byte)220, (byte)40, (byte)40 },
                    { 145, (byte)0, (byte)0, (byte)5, 20070, "lateral right", (byte)0, (byte)40, (byte)240 },
                    { 146, (byte)0, (byte)0, (byte)5, 20071, "lateral right", (byte)0, (byte)80, (byte)200 },
                    { 147, (byte)0, (byte)0, (byte)5, 20072, "lateral right", (byte)0, (byte)0, (byte)20 },
                    { 148, (byte)0, (byte)0, (byte)5, 20073, "lateral right", (byte)220, (byte)0, (byte)0 },
                    { 149, (byte)0, (byte)0, (byte)5, 20074, "lateral right", (byte)0, (byte)200, (byte)240 },
                    { 150, (byte)0, (byte)0, (byte)5, 20075, "lateral right", (byte)40, (byte)0, (byte)0 },
                    { 152, (byte)0, (byte)0, (byte)6, 20001, "medial right", (byte)0, (byte)80, (byte)0 },
                    { 182, (byte)0, (byte)0, (byte)6, 20075, "medial right", (byte)40, (byte)0, (byte)0 },
                    { 207, (byte)0, (byte)0, (byte)7, 20102, "Head", (byte)40, (byte)40, (byte)20 },
                    { 184, (byte)0, (byte)0, (byte)6, 20079, "medial right", (byte)85, (byte)5, (byte)5 },
                    { 217, (byte)0, (byte)0, (byte)8, 20112, "Hand", (byte)240, (byte)160, (byte)0 },
                    { 218, (byte)0, (byte)0, (byte)8, 20113, "Hand", (byte)200, (byte)80, (byte)0 },
                    { 219, (byte)0, (byte)0, (byte)8, 20114, "Hand", (byte)40, (byte)120, (byte)0 },
                    { 220, (byte)0, (byte)0, (byte)8, 20115, "Hand", (byte)120, (byte)120, (byte)0 },
                    { 221, (byte)0, (byte)0, (byte)8, 20116, "Hand", (byte)200, (byte)120, (byte)0 },
                    { 222, (byte)0, (byte)0, (byte)8, 20117, "Hand", (byte)40, (byte)160, (byte)0 },
                    { 223, (byte)0, (byte)0, (byte)8, 20118, "Hand", (byte)120, (byte)160, (byte)0 },
                    { 224, (byte)0, (byte)0, (byte)8, 20119, "Hand", (byte)200, (byte)160, (byte)0 },
                    { 225, (byte)0, (byte)0, (byte)9, 20120, "Foot", (byte)40, (byte)200, (byte)0 },
                    { 226, (byte)0, (byte)0, (byte)9, 20121, "Foot", (byte)80, (byte)240, (byte)0 },
                    { 227, (byte)0, (byte)0, (byte)9, 20122, "Foot", (byte)160, (byte)240, (byte)0 },
                    { 228, (byte)0, (byte)0, (byte)9, 20123, "Foot", (byte)240, (byte)240, (byte)0 },
                    { 229, (byte)0, (byte)0, (byte)9, 20124, "Foot", (byte)80, (byte)0, (byte)40 },
                    { 230, (byte)0, (byte)0, (byte)9, 20125, "Foot", (byte)160, (byte)0, (byte)40 },
                    { 231, (byte)0, (byte)0, (byte)9, 20126, "Foot", (byte)240, (byte)0, (byte)40 },
                    { 232, (byte)0, (byte)0, (byte)9, 20127, "Foot", (byte)0, (byte)250, (byte)20 },
                    { 233, (byte)0, (byte)0, (byte)9, 20128, "Foot", (byte)20, (byte)250, (byte)0 },
                    { 234, (byte)0, (byte)0, (byte)9, 20129, "Foot", (byte)80, (byte)200, (byte)0 },
                    { 235, (byte)0, (byte)0, (byte)9, 20130, "Foot", (byte)40, (byte)240, (byte)0 },
                    { 236, (byte)0, (byte)0, (byte)9, 20131, "Foot", (byte)120, (byte)240, (byte)0 },
                    { 237, (byte)0, (byte)0, (byte)9, 20132, "Foot", (byte)200, (byte)240, (byte)0 },
                    { 238, (byte)0, (byte)0, (byte)9, 20133, "Foot", (byte)40, (byte)0, (byte)40 },
                    { 239, (byte)0, (byte)0, (byte)9, 20134, "Foot", (byte)120, (byte)0, (byte)40 },
                    { 240, (byte)0, (byte)0, (byte)9, 20135, "Foot", (byte)200, (byte)0, (byte)40 },
                    { 241, (byte)0, (byte)0, (byte)9, 20136, "Foot", (byte)250, (byte)20, (byte)0 },
                    { 242, (byte)0, (byte)0, (byte)9, 20137, "Foot", (byte)20, (byte)0, (byte)250 },
                    { 123, (byte)0, (byte)0, (byte)4, 20062, "dorsal", (byte)20, (byte)0, (byte)0 },
                    { 216, (byte)0, (byte)0, (byte)8, 20111, "Hand", (byte)160, (byte)160, (byte)0 },
                    { 183, (byte)0, (byte)0, (byte)6, 20078, "medial right", (byte)5, (byte)245, (byte)245 },
                    { 215, (byte)0, (byte)0, (byte)8, 20110, "Hand", (byte)80, (byte)160, (byte)0 },
                    { 213, (byte)0, (byte)0, (byte)8, 20108, "Hand", (byte)160, (byte)120, (byte)0 },
                    { 185, (byte)0, (byte)0, (byte)7, 20001, "Head", (byte)0, (byte)80, (byte)0 },
                    { 186, (byte)0, (byte)0, (byte)7, 20002, "Head", (byte)0, (byte)120, (byte)0 },
                    { 187, (byte)0, (byte)0, (byte)7, 20080, "Head", (byte)20, (byte)0, (byte)220 },
                    { 188, (byte)0, (byte)0, (byte)7, 20081, "Head", (byte)0, (byte)20, (byte)220 },
                    { 189, (byte)0, (byte)0, (byte)7, 20082, "Head", (byte)0, (byte)40, (byte)160 },
                    { 190, (byte)0, (byte)0, (byte)7, 20083, "Head", (byte)0, (byte)80, (byte)160 },
                    { 191, (byte)0, (byte)0, (byte)7, 20084, "Head", (byte)70, (byte)0, (byte)70 },
                    { 192, (byte)0, (byte)0, (byte)7, 20085, "Head", (byte)0, (byte)0, (byte)70 },
                    { 193, (byte)0, (byte)0, (byte)7, 20086, "Head", (byte)0, (byte)70, (byte)0 },
                    { 194, (byte)0, (byte)0, (byte)7, 20088, "Head", (byte)240, (byte)0, (byte)0 },
                    { 195, (byte)0, (byte)0, (byte)7, 20089, "Head", (byte)40, (byte)40, (byte)0 },
                    { 196, (byte)0, (byte)0, (byte)7, 20090, "Head", (byte)80, (byte)40, (byte)0 },
                    { 197, (byte)0, (byte)0, (byte)7, 20091, "Head", (byte)200, (byte)40, (byte)0 },
                    { 198, (byte)0, (byte)0, (byte)7, 20092, "Head", (byte)160, (byte)80, (byte)0 },
                    { 199, (byte)0, (byte)0, (byte)7, 20093, "Head", (byte)240, (byte)40, (byte)0 },
                    { 200, (byte)0, (byte)0, (byte)7, 20094, "Head", (byte)120, (byte)40, (byte)0 },
                    { 201, (byte)0, (byte)0, (byte)7, 20095, "Head", (byte)90, (byte)90, (byte)90 },
                    { 202, (byte)0, (byte)0, (byte)7, 20096, "Head", (byte)90, (byte)0, (byte)90 },
                    { 203, (byte)0, (byte)0, (byte)7, 20097, "Head", (byte)40, (byte)80, (byte)0 },
                    { 204, (byte)0, (byte)0, (byte)7, 20098, "Head", (byte)80, (byte)80, (byte)0 },
                    { 205, (byte)0, (byte)0, (byte)7, 20099, "Head", (byte)120, (byte)0, (byte)0 },
                    { 206, (byte)0, (byte)0, (byte)7, 20101, "Head", (byte)200, (byte)0, (byte)0 },
                    { 208, (byte)0, (byte)0, (byte)7, 20103, "Head", (byte)80, (byte)40, (byte)20 },
                    { 209, (byte)0, (byte)0, (byte)7, 20104, "Head", (byte)160, (byte)40, (byte)0 },
                    { 210, (byte)0, (byte)0, (byte)7, 20105, "Head", (byte)120, (byte)80, (byte)0 },
                    { 211, (byte)0, (byte)0, (byte)8, 20106, "Hand", (byte)240, (byte)80, (byte)0 },
                    { 212, (byte)0, (byte)0, (byte)8, 20107, "Hand", (byte)80, (byte)120, (byte)0 },
                    { 214, (byte)0, (byte)0, (byte)8, 20109, "Hand", (byte)240, (byte)120, (byte)0 },
                    { 122, (byte)0, (byte)0, (byte)4, 20061, "dorsal", (byte)0, (byte)120, (byte)200 },
                    { 62, (byte)0, (byte)0, (byte)2, 20064, "medial left", (byte)0, (byte)240, (byte)240 },
                    { 120, (byte)0, (byte)0, (byte)4, 20052, "dorsal", (byte)0, (byte)160, (byte)240 },
                    { 32, (byte)0, (byte)0, (byte)1, 20031, "ventral", (byte)180, (byte)0, (byte)0 },
                    { 33, (byte)0, (byte)0, (byte)1, 20032, "ventral", (byte)0, (byte)0, (byte)180 },
                    { 34, (byte)1, (byte)7, (byte)2, 20000, "medial left", (byte)0, (byte)40, (byte)0 },
                    { 35, (byte)0, (byte)0, (byte)2, 20001, "medial left", (byte)0, (byte)80, (byte)0 },
                    { 36, (byte)0, (byte)0, (byte)2, 20002, "medial left", (byte)0, (byte)120, (byte)0 },
                    { 37, (byte)0, (byte)0, (byte)2, 20003, "medial left", (byte)0, (byte)160, (byte)0 },
                    { 38, (byte)0, (byte)0, (byte)2, 20004, "medial left", (byte)0, (byte)200, (byte)0 },
                    { 39, (byte)0, (byte)0, (byte)2, 20006, "medial left", (byte)0, (byte)0, (byte)40 },
                    { 40, (byte)1, (byte)8, (byte)2, 20011, "medial left", (byte)0, (byte)200, (byte)40 },
                    { 41, (byte)1, (byte)8, (byte)2, 20012, "medial left", (byte)0, (byte)240, (byte)40 },
                    { 42, (byte)0, (byte)0, (byte)2, 20013, "medial left", (byte)0, (byte)0, (byte)80 },
                    { 43, (byte)0, (byte)0, (byte)2, 20014, "medial left", (byte)0, (byte)40, (byte)80 },
                    { 31, (byte)0, (byte)0, (byte)1, 20030, "ventral", (byte)0, (byte)60, (byte)60 },
                    { 44, (byte)0, (byte)0, (byte)2, 20015, "medial left", (byte)0, (byte)80, (byte)80 },
                    { 46, (byte)0, (byte)0, (byte)2, 20017, "medial left", (byte)0, (byte)160, (byte)80 },
                    { 47, (byte)0, (byte)0, (byte)2, 20018, "medial left", (byte)0, (byte)200, (byte)80 },
                    { 48, (byte)0, (byte)0, (byte)2, 20019, "medial left", (byte)0, (byte)240, (byte)80 },
                    { 49, (byte)0, (byte)0, (byte)2, 20022, "medial left", (byte)0, (byte)80, (byte)120 },
                    { 50, (byte)0, (byte)0, (byte)2, 20023, "medial left", (byte)0, (byte)120, (byte)120 },
                    { 51, (byte)1, (byte)9, (byte)2, 20026, "medial left", (byte)0, (byte)240, (byte)120 },
                    { 52, (byte)1, (byte)9, (byte)2, 20027, "medial left", (byte)0, (byte)0, (byte)160 },
                    { 54, (byte)0, (byte)0, (byte)2, 20029, "medial left", (byte)60, (byte)60, (byte)60 },
                    { 55, (byte)0, (byte)0, (byte)2, 20030, "medial left", (byte)0, (byte)60, (byte)60 },
                    { 56, (byte)0, (byte)0, (byte)2, 20032, "medial left", (byte)0, (byte)0, (byte)180 },
                    { 57, (byte)0, (byte)0, (byte)2, 20053, "medial left", (byte)225, (byte)125, (byte)45 },
                    { 58, (byte)0, (byte)0, (byte)2, 20054, "medial left", (byte)225, (byte)45, (byte)45 },
                    { 45, (byte)0, (byte)0, (byte)2, 20016, "medial left", (byte)0, (byte)120, (byte)80 },
                    { 30, (byte)0, (byte)0, (byte)1, 20029, "ventral", (byte)60, (byte)60, (byte)60 },
                    { 29, (byte)0, (byte)0, (byte)1, 20028, "ventral", (byte)60, (byte)60, (byte)0 },
                    { 28, (byte)1, (byte)9, (byte)1, 20027, "ventral", (byte)0, (byte)0, (byte)160 },
                    { 1, (byte)1, (byte)7, (byte)1, 20000, "ventral", (byte)0, (byte)40, (byte)0 },
                    { 2, (byte)0, (byte)0, (byte)1, 20001, "ventral", (byte)0, (byte)80, (byte)0 },
                    { 3, (byte)0, (byte)0, (byte)1, 20002, "ventral", (byte)0, (byte)120, (byte)0 },
                    { 4, (byte)0, (byte)0, (byte)1, 20003, "ventral", (byte)0, (byte)160, (byte)0 },
                    { 5, (byte)0, (byte)0, (byte)1, 20004, "ventral", (byte)0, (byte)200, (byte)0 },
                    { 6, (byte)0, (byte)0, (byte)1, 20005, "ventral", (byte)0, (byte)240, (byte)0 },
                    { 7, (byte)0, (byte)0, (byte)1, 20006, "ventral", (byte)0, (byte)0, (byte)40 },
                    { 8, (byte)0, (byte)0, (byte)1, 20007, "ventral", (byte)0, (byte)40, (byte)40 },
                    { 9, (byte)0, (byte)0, (byte)1, 20008, "ventral", (byte)0, (byte)80, (byte)40 },
                    { 10, (byte)0, (byte)0, (byte)1, 20009, "ventral", (byte)0, (byte)120, (byte)40 },
                    { 11, (byte)0, (byte)0, (byte)1, 20010, "ventral", (byte)0, (byte)160, (byte)40 },
                    { 12, (byte)1, (byte)8, (byte)1, 20011, "ventral", (byte)0, (byte)200, (byte)40 },
                    { 13, (byte)1, (byte)8, (byte)1, 20012, "ventral", (byte)0, (byte)240, (byte)40 },
                    { 14, (byte)0, (byte)0, (byte)1, 20013, "ventral", (byte)0, (byte)0, (byte)80 },
                    { 15, (byte)0, (byte)0, (byte)1, 20014, "ventral", (byte)0, (byte)40, (byte)80 },
                    { 16, (byte)0, (byte)0, (byte)1, 20015, "ventral", (byte)0, (byte)80, (byte)80 },
                    { 17, (byte)0, (byte)0, (byte)1, 20016, "ventral", (byte)0, (byte)120, (byte)80 },
                    { 18, (byte)0, (byte)0, (byte)1, 20017, "ventral", (byte)0, (byte)160, (byte)80 },
                    { 19, (byte)0, (byte)0, (byte)1, 20018, "ventral", (byte)0, (byte)200, (byte)80 },
                    { 20, (byte)0, (byte)0, (byte)1, 20019, "ventral", (byte)0, (byte)240, (byte)80 },
                    { 21, (byte)0, (byte)0, (byte)1, 20020, "ventral", (byte)0, (byte)0, (byte)120 },
                    { 22, (byte)0, (byte)0, (byte)1, 20021, "ventral", (byte)0, (byte)40, (byte)120 },
                    { 23, (byte)0, (byte)0, (byte)1, 20022, "ventral", (byte)0, (byte)80, (byte)120 },
                    { 24, (byte)0, (byte)0, (byte)1, 20023, "ventral", (byte)0, (byte)120, (byte)120 },
                    { 25, (byte)0, (byte)0, (byte)1, 20024, "ventral", (byte)0, (byte)160, (byte)120 },
                    { 26, (byte)0, (byte)0, (byte)1, 20025, "ventral", (byte)0, (byte)200, (byte)120 },
                    { 27, (byte)1, (byte)9, (byte)1, 20026, "ventral", (byte)0, (byte)240, (byte)120 },
                    { 59, (byte)0, (byte)0, (byte)2, 20055, "medial left", (byte)220, (byte)80, (byte)40 },
                    { 60, (byte)0, (byte)0, (byte)2, 20057, "medial left", (byte)220, (byte)160, (byte)40 },
                    { 53, (byte)0, (byte)0, (byte)2, 20028, "medial left", (byte)60, (byte)60, (byte)0 },
                    { 121, (byte)0, (byte)0, (byte)4, 20060, "dorsal", (byte)0, (byte)80, (byte)240 },
                    { 93, (byte)0, (byte)0, (byte)4, 20007, "dorsal", (byte)0, (byte)40, (byte)40 },
                    { 94, (byte)0, (byte)0, (byte)4, 20008, "dorsal", (byte)0, (byte)80, (byte)40 },
                    { 95, (byte)0, (byte)0, (byte)4, 20009, "dorsal", (byte)0, (byte)120, (byte)40 },
                    { 96, (byte)0, (byte)0, (byte)4, 20010, "dorsal", (byte)0, (byte)160, (byte)40 },
                    { 97, (byte)1, (byte)8, (byte)4, 20011, "dorsal", (byte)0, (byte)200, (byte)40 },
                    { 61, (byte)0, (byte)0, (byte)2, 20061, "medial left", (byte)0, (byte)120, (byte)200 },
                    { 99, (byte)1, (byte)9, (byte)4, 20026, "dorsal", (byte)0, (byte)240, (byte)120 },
                    { 100, (byte)1, (byte)9, (byte)4, 20027, "dorsal", (byte)0, (byte)0, (byte)160 },
                    { 101, (byte)0, (byte)0, (byte)4, 20031, "dorsal", (byte)180, (byte)0, (byte)0 },
                    { 102, (byte)0, (byte)0, (byte)4, 20032, "dorsal", (byte)0, (byte)0, (byte)180 },
                    { 103, (byte)0, (byte)0, (byte)4, 20035, "dorsal", (byte)0, (byte)100, (byte)0 },
                    { 104, (byte)0, (byte)0, (byte)4, 20036, "dorsal", (byte)100, (byte)0, (byte)0 },
                    { 105, (byte)0, (byte)0, (byte)4, 20037, "dorsal", (byte)0, (byte)120, (byte)160 },
                    { 106, (byte)0, (byte)0, (byte)4, 20038, "dorsal", (byte)0, (byte)160, (byte)160 },
                    { 107, (byte)0, (byte)0, (byte)4, 20039, "dorsal", (byte)100, (byte)40, (byte)0 },
                    { 108, (byte)0, (byte)0, (byte)4, 20040, "dorsal", (byte)0, (byte)100, (byte)40 },
                    { 109, (byte)0, (byte)0, (byte)4, 20041, "dorsal", (byte)0, (byte)200, (byte)160 },
                    { 110, (byte)0, (byte)0, (byte)4, 20042, "dorsal", (byte)0, (byte)240, (byte)160 },
                    { 111, (byte)0, (byte)0, (byte)4, 20043, "dorsal", (byte)0, (byte)0, (byte)200 },
                    { 112, (byte)0, (byte)0, (byte)4, 20044, "dorsal", (byte)0, (byte)40, (byte)200 },
                    { 113, (byte)0, (byte)0, (byte)4, 20045, "dorsal", (byte)0, (byte)180, (byte)100 },
                    { 114, (byte)0, (byte)0, (byte)4, 20046, "dorsal", (byte)100, (byte)180, (byte)0 },
                    { 115, (byte)0, (byte)0, (byte)4, 20047, "dorsal", (byte)0, (byte)240, (byte)200 },
                    { 116, (byte)0, (byte)0, (byte)4, 20048, "dorsal", (byte)0, (byte)0, (byte)240 },
                    { 117, (byte)0, (byte)0, (byte)4, 20049, "dorsal", (byte)0, (byte)120, (byte)240 },
                    { 118, (byte)0, (byte)0, (byte)4, 20050, "dorsal", (byte)250, (byte)0, (byte)0 },
                    { 119, (byte)0, (byte)0, (byte)4, 20051, "dorsal", (byte)250, (byte)250, (byte)250 },
                    { 92, (byte)0, (byte)0, (byte)4, 20006, "dorsal", (byte)0, (byte)0, (byte)40 },
                    { 91, (byte)0, (byte)0, (byte)4, 20005, "dorsal", (byte)0, (byte)240, (byte)0 },
                    { 98, (byte)1, (byte)8, (byte)4, 20012, "dorsal", (byte)0, (byte)240, (byte)40 },
                    { 89, (byte)1, (byte)0, (byte)3, 20066, "lateral left", (byte)0, (byte)0, (byte)100 },
                    { 63, (byte)0, (byte)0, (byte)2, 20065, "medial left", (byte)80, (byte)0, (byte)0 },
                    { 64, (byte)0, (byte)0, (byte)2, 20070, "medial left", (byte)0, (byte)40, (byte)240 },
                    { 65, (byte)0, (byte)0, (byte)2, 20073, "medial left", (byte)220, (byte)0, (byte)0 },
                    { 66, (byte)0, (byte)0, (byte)2, 20076, "medial left", (byte)5, (byte)205, (byte)245 },
                    { 67, (byte)0, (byte)0, (byte)2, 20077, "medial left", (byte)45, (byte)5, (byte)5 },
                    { 90, (byte)1, (byte)7, (byte)4, 20000, "dorsal", (byte)0, (byte)40, (byte)0 },
                    { 69, (byte)0, (byte)0, (byte)3, 20002, "lateral left", (byte)0, (byte)120, (byte)0 },
                    { 70, (byte)0, (byte)0, (byte)3, 20004, "lateral left", (byte)0, (byte)200, (byte)0 },
                    { 71, (byte)0, (byte)0, (byte)3, 20006, "lateral left", (byte)0, (byte)0, (byte)40 },
                    { 72, (byte)1, (byte)8, (byte)3, 20012, "lateral left", (byte)0, (byte)240, (byte)40 },
                    { 73, (byte)0, (byte)0, (byte)3, 20014, "lateral left", (byte)0, (byte)40, (byte)80 },
                    { 74, (byte)0, (byte)0, (byte)3, 20016, "lateral left", (byte)0, (byte)120, (byte)80 },
                    { 75, (byte)0, (byte)0, (byte)3, 20018, "lateral left", (byte)0, (byte)200, (byte)80 },
                    { 68, (byte)1, (byte)7, (byte)3, 20000, "lateral left", (byte)0, (byte)40, (byte)0 },
                    { 77, (byte)0, (byte)0, (byte)3, 20023, "lateral left", (byte)0, (byte)120, (byte)120 },
                    { 76, (byte)0, (byte)0, (byte)3, 20019, "lateral left", (byte)0, (byte)240, (byte)80 },
                    { 88, (byte)0, (byte)0, (byte)3, 20065, "lateral left", (byte)80, (byte)0, (byte)0 },
                    { 87, (byte)0, (byte)0, (byte)3, 20064, "lateral left", (byte)0, (byte)240, (byte)240 },
                    { 86, (byte)0, (byte)0, (byte)3, 20063, "lateral left", (byte)0, (byte)220, (byte)0 },
                    { 84, (byte)0, (byte)0, (byte)3, 20061, "lateral left", (byte)0, (byte)120, (byte)200 },
                    { 85, (byte)0, (byte)0, (byte)3, 20062, "lateral left", (byte)20, (byte)0, (byte)0 },
                    { 82, (byte)0, (byte)0, (byte)3, 20057, "lateral left", (byte)220, (byte)160, (byte)40 },
                    { 81, (byte)0, (byte)0, (byte)3, 20055, "lateral left", (byte)220, (byte)80, (byte)40 },
                    { 80, (byte)0, (byte)0, (byte)3, 20036, "lateral left", (byte)100, (byte)0, (byte)180 },
                    { 79, (byte)0, (byte)0, (byte)3, 20032, "lateral left", (byte)0, (byte)0, (byte)180 },
                    { 78, (byte)1, (byte)9, (byte)3, 20027, "lateral left", (byte)0, (byte)0, (byte)160 },
                    { 83, (byte)0, (byte)0, (byte)3, 20060, "lateral left", (byte)0, (byte)80, (byte)240 }
                });

            migrationBuilder.InsertData(
                table: "DEFPublicDBItems",
                columns: new[] { "id", "data_format", "is_table", "obj_identifier", "object_name", "represented_name", "represented_string", "tbl" },
                values: new object[,]
                {
                    { 21, 3, false, "elm", "exdate", 0, "Excision Date", "_mikro" },
                    { 26, 3, false, "tim", "date_created", 0, "Creation Date", "_timestamps" },
                    { 22, 0, true, "dia", "_imgdiag", 0, "Diagnoses", null },
                    { 23, 2, false, "dia", "fullname", 0, "Diagnosis Name", "_diagnoses" },
                    { 24, 2, false, "dia", "risk", 0, "Diagnosis Risk", "_diagnoses" },
                    { 25, 0, true, "tim", "_timestamps", 0, "Time", null },
                    { 27, 3, false, "tim", "date_last_accessed", 0, "Last Accession Date", "_timestamps" },
                    { 34, 2, false, "his", "diagnose", 0, "Diagnose", "_histos" },
                    { 29, 2, false, "doc", "docname", 0, "Document Name", "_documents" },
                    { 30, 0, true, "cos", "_cosmetic", 0, "Cosmetical Images", null },
                    { 31, 1, false, "cos", "treatment_id", 0, "Kind of Treatment", "_cosmetic" },
                    { 32, 0, true, "his", "_histos", 0, "Histopathological Image", null },
                    { 35, 2, false, "his", "histo_nr", 0, "Histopathological Number", "_histos" },
                    { 20, 2, false, "elm", "excision", 0, "Excision Status", "_mikro" },
                    { 28, 0, true, "doc", "_documents", 0, "Atteched Documents", null },
                    { 19, 1, false, "img", "origin", 0, "Image Source", "_images" },
                    { 33, 2, false, "his", "examinator", 0, "Examinator", "_histos" },
                    { 17, 0, true, "elm", "elm", 0, "ELM Image", "_images" },
                    { 1, 0, true, "pat", "_patients", 0, "Patients", null },
                    { 2, 2, false, "pat", "lastname", 0, "Lastname", "_patients" }
                });

            migrationBuilder.InsertData(
                table: "DEFPublicDBItems",
                columns: new[] { "id", "data_format", "is_table", "obj_identifier", "object_name", "represented_name", "represented_string", "tbl" },
                values: new object[,]
                {
                    { 3, 2, false, "pat", "firstname", 0, "Firstname", "_patients" },
                    { 4, 3, false, "pat", "birthdate", 0, "Birthdate", "_patients" },
                    { 5, 2, false, "pat", "sex", 0, "Sex", "_patients" },
                    { 6, 2, false, "pat", "insnr", 0, "Insurance Number", "_patients" },
                    { 7, 2, false, "pat", "insnr_usa", 0, "Social Security Number", "_patients" },
                    { 18, 2, false, "img", "loctext", 0, "Location", "_images" },
                    { 9, 2, false, "pat", "address", 0, "Address", "_patients" },
                    { 10, 2, false, "pat", "city", 0, "City", "_patients" },
                    { 11, 2, false, "pat", "state", 0, "State", "_patients" },
                    { 12, 2, false, "pat", "e_mail", 0, "E-Mail", "_patients" },
                    { 13, 3, false, "pat", "fup_date", 0, "Follow Up Date", "_patients" },
                    { 8, 2, false, "pat", "insident", 0, "Insurance Identification", "_patients" },
                    { 14, 0, true, "img", "_images", 0, "Images", null },
                    { 15, 1, false, "img", "kind", 0, "Kind of Image", "_images" }
                });

            migrationBuilder.InsertData(
                table: "Ethnicgroup",
                columns: new[] { "ID", "info" },
                values: new object[,]
                {
                    { 4, "White" },
                    { 3, "Hispanic" },
                    { 1, "Asian" },
                    { 2, "Black" }
                });

            migrationBuilder.InsertData(
                table: "ExpertizerABCD",
                columns: new[] { "ID", "A_Score", "B_Score", "C_Score", "D_Score", "Diagnosis", "ImageID" },
                values: new object[,]
                {
                    { 195, 0, 8, 911999, 19999, 41500, "abcd\\wr000016.bmp" },
                    { 198, 0, 0, 911999, 91999, 41502, "abcd\\wt000018.bmp" },
                    { 197, 1, 0, 911999, 11999, 41502, "abcd\\wt000015.bmp" },
                    { 199, 0, 0, 911999, 11999, 41502, "abcd\\wt000021.bmp" },
                    { 196, 1, 0, 911999, 11999, 41502, "abcd\\wt000014.bmp" },
                    { 194, 0, 0, 919999, 11999, 41500, "abcd\\wh000001.bmp" },
                    { 188, 1, 0, 991999, 11991, 41502, "abcd\\we000004.bmp" },
                    { 192, 0, 0, 911999, 91919, 41502, "abcd\\we000008.bmp" },
                    { 191, 0, 0, 911999, 11911, 41502, "abcd\\we000007.bmp" },
                    { 190, 0, 0, 911999, 91919, 41502, "abcd\\we000006.bmp" },
                    { 189, 0, 0, 911999, 91991, 41502, "abcd\\we000005.bmp" },
                    { 200, 0, 0, 911999, 11999, 41502, "abcd\\wt000023.bmp" },
                    { 187, 0, 0, 991999, 11991, 41502, "abcd\\we000003.bmp" },
                    { 186, 1, 0, 911999, 91999, 41500, "abcd\\wd000025.bmp" },
                    { 193, 2, 0, 111111, 11919, 41503, "abcd\\wg000002.bmp" },
                    { 201, 0, 0, 911999, 11999, 41502, "abcd\\zw000009.bmp" },
                    { 207, 0, 0, 911999, 19991, 41500, "abcd\\bd000046.bmp" },
                    { 203, 1, 0, 911991, 19991, 41502, "abcd\\ai000003.bmp" },
                    { 217, 0, 0, 911999, 11991, 41500, "abcd\\bs000231.bmp" },
                    { 216, 0, 0, 911919, 19911, 41502, "abcd\\bm000382.bmp" },
                    { 215, 1, 1, 911919, 11911, 41502, "abcd\\bk000054.bmp" },
                    { 214, 0, 0, 911999, 99991, 41500, "abcd\\bg000116.bmp" },
                    { 213, 0, 0, 911999, 11999, 41500, "abcd\\bg000110.bmp" },
                    { 212, 0, 0, 911999, 11919, 41500, "abcd\\bg000105.bmp" },
                    { 202, 1, 0, 911999, 91119, 41502, "abcd\\zw000010.bmp" },
                    { 211, 0, 0, 911919, 19991, 41500, "abcd\\bg000104.bmp" },
                    { 210, 0, 0, 911999, 19991, 41500, "abcd\\be000060.bmp" },
                    { 209, 0, 0, 911999, 19991, 41500, "abcd\\be000059.bmp" },
                    { 208, 0, 0, 911999, 19991, 41500, "abcd\\be000058.bmp" },
                    { 206, 2, 0, 911991, 19919, 41502, "abcd\\ai000008.bmp" },
                    { 205, 1, 0, 911999, 11119, 41502, "abcd\\ai000006.bmp" },
                    { 204, 1, 0, 911999, 91999, 41502, "abcd\\ai000005.bmp" },
                    { 185, 0, 0, 911999, 91999, 41500, "abcd\\wd000024.bmp" },
                    { 184, 0, 0, 911999, 11919, 41500, "abcd\\wd000008.bmp" },
                    { 174, 0, 0, 911919, 11919, 41500, "abcd\\ta000000.bmp" },
                    { 182, 0, 0, 911999, 91999, 41500, "abcd\\wc000001.bmp" },
                    { 162, 0, 0, 911999, 11919, 41500, "abcd\\sr000020.bmp" },
                    { 161, 0, 0, 911999, 11999, 41500, "abcd\\sr000019.bmp" },
                    { 160, 0, 0, 911999, 11999, 41502, "abcd\\sr000013.bmp" },
                    { 159, 0, 0, 911999, 11919, 41502, "abcd\\sr000012.bmp" },
                    { 158, 0, 0, 911999, 91999, 41500, "abcd\\sm000029.bmp" },
                    { 157, 0, 0, 911999, 11999, 41500, "abcd\\sm000028.bmp" },
                    { 163, 0, 0, 911999, 11919, 41502, "abcd\\sr000023.bmp" },
                    { 156, 0, 0, 911999, 11999, 41500, "abcd\\sm000026.bmp" },
                    { 154, 2, 0, 911119, 11119, 41503, "abcd\\sm000010.bmp" },
                    { 153, 0, 0, 911999, 11999, 41500, "abcd\\sm000003.bmp" },
                    { 152, 2, 0, 911111, 11199, 41503, "abcd\\sj000008.bmp" },
                    { 151, 2, 0, 911919, 11119, 41503, "abcd\\sj000003.bmp" },
                    { 150, 2, 0, 111199, 99991, 41503, "abcd\\sh000066.bmp" },
                    { 149, 1, 0, 911919, 11919, 41502, "abcd\\sh000024.bmp" },
                    { 155, 0, 0, 919999, 11991, 41502, "abcd\\sm000014.bmp" },
                    { 164, 1, 0, 999991, 11991, 41502, "abcd\\ss000000.bmp" },
                    { 165, 1, 0, 911999, 99991, 41500, "abcd\\ss000002.bmp" },
                    { 166, 1, 0, 911999, 91991, 41502, "abcd\\ss000006.bmp" },
                    { 181, 0, 0, 919999, 91999, 41500, "abcd\\wa000004.bmp" },
                    { 180, 0, 0, 919999, 11991, 41500, "abcd\\vm000008.bmp" },
                    { 179, 2, 0, 111191, 11999, 41503, "abcd\\tm000020.bmp" },
                    { 178, 0, 8, 911919, 19999, 41500, "abcd\\tm000012.bmp" },
                    { 177, 0, 0, 911999, 11999, 41500, "abcd\\tm000006.bmp" },
                    { 176, 1, 0, 911919, 11119, 41502, "abcd\\tj000001.bmp" },
                    { 175, 0, 0, 911919, 11999, 41502, "abcd\\ti000001.bmp" },
                    { 218, 1, 0, 911991, 11999, 41502, "abcd\\ca000472.bmp" },
                    { 173, 0, 0, 911999, 11999, 41500, "abcd\\sw000112.bmp" },
                    { 172, 0, 0, 919999, 19999, 41500, "abcd\\sw000104.bmp" },
                    { 171, 0, 0, 911999, 11919, 41500, "abcd\\sw000103.bmp" },
                    { 170, 0, 0, 919999, 11999, 41502, "abcd\\sw000039.bmp" },
                    { 169, 0, 0, 911999, 11919, 41500, "abcd\\sw000038.bmp" },
                    { 168, 0, 0, 911999, 11999, 41500, "abcd\\st000000.bmp" },
                    { 167, 2, 3, 911919, 11999, 41502, "abcd\\ss000041.bmp" },
                    { 183, 0, 0, 919999, 19991, 41502, "abcd\\wc000003.bmp" },
                    { 219, 1, 0, 119991, 11999, 41502, "abcd\\ca000483.bmp" },
                    { 230, 1, 0, 911999, 11919, 41502, "abcd\\hb000092.bmp" },
                    { 221, 0, 0, 919991, 19999, 41502, "abcd\\ea000227.bmp" },
                    { 273, 0, 0, 911119, 11999, 41502, "abcd\\nc000058.bmp" },
                    { 272, 0, 0, 911999, 11919, 41502, "abcd\\nc000057.bmp" },
                    { 271, 0, 0, 911999, 11919, 41502, "abcd\\le000034.bmp" },
                    { 270, 1, 0, 911999, 91999, 41502, "abcd\\le000032.bmp" },
                    { 269, 0, 0, 911999, 11199, 41500, "abcd\\kk000201.bmp" },
                    { 268, 2, 4, 911119, 11919, 41503, "abcd\\kh000098.bmp" },
                    { 274, 0, 0, 911999, 11999, 41502, "abcd\\nc000059.bmp" },
                    { 267, 0, 0, 911999, 11119, 41502, "abcd\\kg000212.bmp" },
                    { 265, 0, 0, 911999, 19119, 41502, "abcd\\kg000204.bmp" },
                    { 264, 1, 0, 911919, 11911, 41502, "abcd\\kg000202.bmp" },
                    { 263, 0, 0, 911999, 11919, 41500, "abcd\\kc000225.bmp" },
                    { 262, 2, 5, 111119, 19111, 41503, "abcd\\ka000163.bmp" },
                    { 261, 1, 0, 919999, 11919, 41502, "abcd\\js000008.bmp" },
                    { 260, 0, 0, 911999, 19919, 41502, "abcd\\jr000129.bmp" },
                    { 266, 0, 0, 911119, 11911, 41503, "abcd\\kg000206.bmp" },
                    { 275, 0, 0, 911999, 11999, 41502, "abcd\\nc000060.bmp" },
                    { 276, 0, 0, 911999, 11999, 41502, "abcd\\nc000061.bmp" },
                    { 277, 0, 0, 911999, 11999, 41502, "abcd\\nc000062.bmp" },
                    { 148, 1, 0, 911919, 11999, 41502, "abcd\\sh000016.bmp" },
                    { 291, 2, 0, 911999, 11119, 41503, "abcd\\n9.bmp" },
                    { 290, 2, 7, 991111, 19111, 41503, "abcd\\n3.bmp" },
                    { 289, 2, 6, 911999, 11191, 41503, "abcd\\n13.bmp" },
                    { 288, 1, 0, 911199, 11919, 41502, "abcd\\n12.bmp" },
                    { 287, 2, 1, 911111, 19111, 41503, "abcd\\n11.bmp" },
                    { 286, 1, 6, 911119, 11199, 41503, "abcd\\n10.bmp" },
                    { 285, 1, 8, 991999, 91199, 41502, "abcd\\n1.bmp" },
                    { 284, 0, 0, 911999, 91991, 41500, "abcd\\pd000020.bmp" },
                    { 283, 0, 0, 911999, 11999, 41500, "abcd\\pd000019.bmp" },
                    { 282, 0, 0, 911999, 11919, 41500, "abcd\\os000028.bmp" },
                    { 281, 0, 0, 911919, 99991, 41500, "abcd\\nc000079.bmp" },
                    { 280, 1, 0, 911999, 19991, 41502, "abcd\\nc000075.bmp" },
                    { 279, 1, 0, 911999, 99991, 41500, "abcd\\nc000073.bmp" },
                    { 278, 0, 0, 911919, 11199, 41500, "abcd\\nc000065.bmp" },
                    { 259, 0, 0, 911999, 11919, 41502, "abcd\\jr000126.bmp" },
                    { 220, 1, 7, 119119, 19199, 41503, "abcd\\ci000020.bmp" },
                    { 258, 0, 0, 911919, 19911, 41500, "abcd\\jm000054.bmp" },
                    { 256, 2, 2, 111111, 11111, 41503, "abcd\\jh000039.bmp" },
                    { 236, 2, 0, 911999, 11919, 41502, "abcd\\hb000127.bmp" },
                    { 235, 0, 0, 911999, 91119, 41502, "abcd\\hb000114.bmp" },
                    { 234, 0, 0, 911999, 19919, 41502, "abcd\\hb000113.bmp" },
                    { 233, 0, 0, 911999, 11119, 41502, "abcd\\hb000112.bmp" },
                    { 232, 0, 0, 911999, 11919, 41502, "abcd\\hb000108.bmp" },
                    { 231, 1, 0, 911999, 11919, 41502, "abcd\\hb000094.bmp" },
                    { 237, 0, 0, 911999, 11919, 41500, "abcd\\hb000129.bmp" },
                    { 229, 1, 5, 911919, 11911, 41502, "abcd\\hb000089.bmp" },
                    { 227, 1, 0, 911919, 91999, 41502, "abcd\\gh000044.bmp" },
                    { 226, 0, 0, 911999, 91999, 41502, "abcd\\er000090.bmp" },
                    { 225, 0, 0, 919999, 19991, 41500, "abcd\\er000085.bmp" },
                    { 224, 1, 0, 111111, 19111, 41503, "abcd\\eb000057.bmp" },
                    { 223, 1, 0, 911991, 19999, 41502, "abcd\\ea000236.bmp" },
                    { 222, 0, 0, 919991, 19991, 41502, "abcd\\ea000231.bmp" },
                    { 228, 0, 0, 911999, 11999, 41502, "abcd\\ha000086.bmp" },
                    { 238, 1, 0, 911999, 11919, 41502, "abcd\\hb000133.bmp" },
                    { 239, 2, 0, 911919, 11119, 41502, "abcd\\hc000079.bmp" },
                    { 240, 1, 0, 911999, 99991, 41500, "abcd\\hc000080.bmp" },
                    { 255, 0, 0, 919999, 19991, 41500, "abcd\\hr000099.bmp" },
                    { 254, 0, 0, 919999, 91991, 41502, "abcd\\hr000095.bmp" },
                    { 253, 1, 0, 911999, 19991, 41502, "abcd\\hp000079.bmp" },
                    { 252, 0, 8, 911919, 19999, 41500, "abcd\\hm000344.bmp" },
                    { 251, 1, 0, 911919, 11919, 41502, "abcd\\hm000235.bmp" },
                    { 250, 2, 0, 911999, 11991, 41502, "abcd\\hj000160.bmp" },
                    { 249, 0, 0, 911911, 91919, 41502, "abcd\\hh000173.bmp" },
                    { 248, 0, 0, 919999, 11991, 41502, "abcd\\hh000172.bmp" },
                    { 247, 2, 2, 911111, 11119, 41503, "abcd\\hg000078.bmp" },
                    { 246, 0, 0, 911999, 11999, 41500, "abcd\\hf000083.bmp" },
                    { 245, 0, 0, 911999, 11999, 41500, "abcd\\hf000082.bmp" },
                    { 244, 1, 0, 911999, 11999, 41502, "abcd\\he000325.bmp" },
                    { 243, 2, 4, 911919, 11119, 41503, "abcd\\hc000135.bmp" },
                    { 242, 1, 0, 911919, 11911, 41502, "abcd\\hc000086.bmp" },
                    { 241, 0, 0, 911999, 91919, 41500, "abcd\\hc000084.bmp" },
                    { 257, 2, 3, 911919, 11919, 41503, "abcd\\jj000006.bmp" },
                    { 147, 1, 0, 911919, 11919, 41502, "abcd\\sh000015.bmp" },
                    { 119, 0, 0, 919999, 11999, 41502, "abcd\\pm000005.bmp" },
                    { 145, 0, 0, 911999, 91999, 41502, "abcd\\se000011.bmp" },
                    { 51, 1, 0, 911991, 11919, 41502, "abcd\\kk000027.bmp" },
                    { 50, 0, 0, 911999, 19991, 41500, "abcd\\kk000024.bmp" },
                    { 49, 2, 3, 111111, 11919, 41503, "abcd\\kj000125.bmp" },
                    { 48, 0, 0, 919911, 11919, 41502, "abcd\\kj000005.bmp" },
                    { 47, 0, 0, 919999, 11999, 41502, "abcd\\kj000002.bmp" },
                    { 46, 1, 0, 911999, 11911, 41502, "abcd\\kh000015.bmp" },
                    { 52, 0, 0, 911999, 11991, 41502, "abcd\\kk000031.bmp" },
                    { 45, 0, 0, 911999, 11999, 41500, "abcd\\kg000036.bmp" },
                    { 43, 1, 0, 911919, 11919, 41502, "abcd\\kf000064.bmp" },
                    { 42, 0, 0, 919999, 11119, 41502, "abcd\\kb000044.bmp" },
                    { 41, 1, 1, 911919, 11919, 41502, "abcd\\kb000004.bmp" },
                    { 40, 1, 0, 911999, 11919, 41502, "abcd\\ka000014.bmp" },
                    { 39, 0, 0, 911999, 11919, 41502, "abcd\\jr000010.bmp" },
                    { 38, 0, 0, 911999, 11991, 41500, "abcd\\jr000007.bmp" },
                    { 44, 0, 0, 911999, 91111, 41502, "abcd\\kg000003.bmp" },
                    { 53, 2, 0, 111199, 11911, 41503, "abcd\\kk000094.bmp" },
                    { 54, 0, 0, 911999, 91999, 41502, "abcd\\km000015.bmp" },
                    { 55, 0, 0, 919999, 91919, 41502, "abcd\\km000016.bmp" },
                    { 70, 1, 6, 911119, 11119, 41503, "abcd\\lg000013.bmp" },
                    { 69, 1, 0, 911119, 11199, 41503, "abcd\\le000026.bmp" },
                    { 68, 0, 0, 911999, 11991, 41500, "abcd\\lc000002.bmp" },
                    { 67, 0, 0, 911999, 19991, 41500, "abcd\\lc000000.bmp" },
                    { 66, 0, 0, 919999, 91999, 41500, "abcd\\kw000005.bmp" },
                    { 65, 0, 0, 919999, 11919, 41500, "abcd\\kw000004.bmp" },
                    { 64, 0, 0, 919999, 11999, 41500, "abcd\\kw000000.bmp" },
                    { 63, 0, 0, 911199, 11919, 41502, "abcd\\kn000017.bmp" },
                    { 62, 1, 0, 911999, 11911, 41502, "abcd\\kn000015.bmp" },
                    { 61, 0, 0, 919999, 11991, 41500, "abcd\\kn000010.bmp" },
                    { 60, 0, 0, 919999, 11991, 41500, "abcd\\kn000009.bmp" },
                    { 59, 0, 0, 911919, 91911, 41502, "abcd\\kn000005.bmp" },
                    { 58, 0, 0, 911999, 19111, 41502, "abcd\\km000049.bmp" },
                    { 57, 1, 0, 911999, 11991, 41502, "abcd\\km000046.bmp" },
                    { 56, 0, 0, 911919, 11919, 41502, "abcd\\km000033.bmp" },
                    { 37, 0, 0, 911999, 11991, 41502, "abcd\\jr000006.bmp" },
                    { 71, 2, 0, 911919, 11999, 41503, "abcd\\lh000002.bmp" },
                    { 36, 1, 0, 911999, 11991, 41502, "abcd\\jr000005.bmp" },
                    { 34, 1, 0, 911999, 11919, 41502, "abcd\\jr000002.bmp" },
                    { 14, 0, 0, 991999, 91999, 41500, "abcd\\c1.bmp" },
                    { 13, 2, 3, 911919, 11911, 41503, "abcd\\bp000005.bmp" },
                    { 12, 1, 2, 911919, 91199, 41502, "abcd\\a9.bmp" },
                    { 11, 1, 0, 911191, 11919, 41502, "abcd\\a8.bmp" },
                    { 10, 1, 0, 111999, 11919, 41502, "abcd\\a7.bmp" },
                    { 9, 1, 0, 911999, 11999, 41502, "abcd\\a6.bmp" },
                    { 15, 0, 0, 911999, 91919, 41500, "abcd\\c10.bmp" },
                    { 8, 1, 0, 911911, 91999, 41502, "abcd\\a5.bmp" },
                    { 6, 1, 0, 911999, 11991, 41502, "abcd\\a2.bmp" },
                    { 5, 0, 0, 919999, 11191, 41500, "abcd\\a15.bmp" },
                    { 4, 0, 0, 919999, 11191, 41500, "abcd\\a14.bmp" },
                    { 3, 1, 0, 911919, 11919, 41502, "abcd\\a13.bmp" },
                    { 2, 0, 0, 911999, 91999, 41502, "abcd\\a10.bmp" },
                    { 1, 1, 0, 911199, 91199, 41502, "abcd\\a1.bmp" },
                    { 7, 0, 0, 911199, 11999, 41502, "abcd\\a3.bmp" },
                    { 16, 0, 0, 911999, 99991, 41500, "abcd\\c2.bmp" },
                    { 17, 0, 8, 991119, 19991, 41501, "abcd\\c3.bmp" },
                    { 18, 0, 0, 911999, 11991, 41502, "abcd\\c4.bmp" },
                    { 33, 1, 6, 999111, 19911, 41503, "abcd\\jo000001.bmp" },
                    { 32, 2, 3, 911919, 11119, 41503, "abcd\\jj000004.bmp" },
                    { 31, 1, 0, 911911, 19911, 41503, "abcd\\hj000121.bmp" },
                    { 30, 2, 0, 911919, 19911, 41503, "abcd\\hj000115.bmp" },
                    { 29, 0, 0, 911999, 11119, 41502, "abcd\\he000233.bmp" },
                    { 28, 1, 0, 911999, 11999, 41502, "abcd\\gs000129.bmp" },
                    { 27, 2, 4, 911119, 19119, 41503, "abcd\\gf000001.bmp" },
                    { 26, 2, 4, 111111, 19911, 41503, "abcd\\fw000000.bmp" },
                    { 25, 1, 8, 991919, 11119, 41502, "abcd\\ds000021.bmp" },
                    { 24, 1, 0, 911911, 19119, 41503, "abcd\\de000007.bmp" },
                    { 23, 0, 0, 911119, 11119, 41501, "abcd\\c9.bmp" },
                    { 22, 0, 6, 991919, 19991, 41500, "abcd\\c8.bmp" },
                    { 146, 0, 0, 911999, 91919, 41502, "abcd\\sh000013.bmp" },
                    { 20, 1, 0, 911999, 11999, 41502, "abcd\\c6.bmp" },
                    { 19, 0, 0, 911919, 11919, 41502, "abcd\\c5.bmp" },
                    { 35, 0, 0, 911999, 19991, 41502, "abcd\\jr000004.bmp" },
                    { 72, 0, 0, 911919, 19991, 41500, "abcd\\lm000036.bmp" },
                    { 21, 0, 0, 911919, 91919, 41502, "abcd\\c7.bmp" },
                    { 74, 0, 0, 911999, 11991, 41502, "abcd\\lt000001.bmp" },
                    { 126, 1, 0, 911999, 91919, 41502, "abcd\\pw000003.bmp" },
                    { 125, 0, 0, 911999, 91919, 41502, "abcd\\pw000002.bmp" },
                    { 124, 0, 0, 911999, 11991, 41502, "abcd\\ps000011.bmp" },
                    { 123, 1, 0, 911999, 11919, 41502, "abcd\\pp000064.bmp" },
                    { 122, 0, 0, 911919, 11919, 41502, "abcd\\pp000005.bmp" },
                    { 121, 1, 0, 911999, 11999, 41500, "abcd\\pp000003.bmp" },
                    { 127, 1, 4, 911999, 11119, 41503, "abcd\\pw000019.bmp" },
                    { 120, 0, 0, 911999, 11191, 41502, "abcd\\pm000071.bmp" },
                    { 117, 0, 0, 919999, 11999, 41500, "abcd\\pi000000.bmp" },
                    { 116, 0, 0, 919999, 11999, 41500, "abcd\\pf000001.bmp" },
                    { 115, 0, 0, 911999, 11999, 41502, "abcd\\pb000009.bmp" },
                    { 114, 0, 3, 911999, 11999, 41500, "abcd\\pa000008.bmp" },
                    { 113, 1, 1, 911999, 11999, 41502, "abcd\\pa000006.bmp" },
                    { 112, 1, 0, 911919, 11119, 41502, "abcd\\pa000001.bmp" },
                    { 118, 0, 0, 911919, 19919, 41502, "abcd\\pl000005.bmp" },
                    { 111, 0, 0, 911999, 11991, 41502, "abcd\\or000014.bmp" },
                    { 128, 0, 0, 919999, 19991, 41502, "abcd\\rb000013.bmp" },
                    { 130, 1, 0, 911999, 11111, 41502, "abcd\\rb000030.bmp" },
                    { 73, 0, 0, 911919, 11999, 41502, "abcd\\lt000000.bmp" },
                    { 144, 0, 0, 911999, 91999, 41500, "abcd\\se000008.bmp" },
                    { 143, 1, 0, 911999, 11999, 41500, "abcd\\sb000066.bmp" },
                    { 142, 0, 0, 911919, 11999, 41500, "abcd\\sa000025.bmp" },
                    { 141, 0, 0, 911999, 11999, 41500, "abcd\\sa000023.bmp" },
                    { 140, 0, 0, 911919, 19991, 41500, "abcd\\sa000007.bmp" },
                    { 129, 0, 0, 919999, 11119, 41502, "abcd\\rb000028.bmp" },
                    { 139, 0, 0, 911999, 99991, 41500, "abcd\\sa000000.bmp" },
                    { 137, 1, 0, 911919, 11919, 41502, "abcd\\rf000087.bmp" },
                    { 136, 0, 0, 911999, 11919, 41502, "abcd\\rf000012.bmp" },
                    { 135, 0, 0, 911999, 11919, 41502, "abcd\\rf000007.bmp" },
                    { 133, 0, 0, 911999, 11999, 41502, "abcd\\rf000004.bmp" },
                    { 132, 1, 0, 911999, 19991, 41502, "abcd\\rf000001.bmp" },
                    { 131, 0, 0, 911999, 11919, 41502, "abcd\\rf000000.bmp" },
                    { 138, 0, 0, 911919, 11999, 41500, "abcd\\rh000000.bmp" },
                    { 110, 1, 4, 911999, 11119, 41502, "abcd\\or000002.bmp" },
                    { 134, 0, 0, 911999, 11119, 41502, "abcd\\rf000006.bmp" },
                    { 108, 1, 0, 911919, 11999, 41502, "abcd\\nt000006.bmp" },
                    { 89, 0, 0, 911919, 19919, 41500, "abcd\\mg000007.bmp" },
                    { 88, 0, 0, 911999, 11999, 41500, "abcd\\mg000004.bmp" },
                    { 87, 1, 0, 911919, 11999, 41502, "abcd\\mf000002.bmp" },
                    { 86, 0, 8, 991919, 19199, 41500, "abcd\\md000004.bmp" },
                    { 85, 0, 6, 911999, 19991, 41500, "abcd\\md000002.bmp" },
                    { 84, 0, 6, 911999, 19991, 41500, "abcd\\md000001.bmp" },
                    { 83, 1, 0, 119991, 19999, 41503, "abcd\\m9.bmp" },
                    { 82, 2, 2, 911119, 11919, 41503, "abcd\\m8.bmp" },
                    { 80, 2, 1, 111119, 11119, 41503, "abcd\\m6.bmp" },
                    { 79, 2, 3, 111911, 11199, 41503, "abcd\\m5.bmp" },
                    { 78, 2, 1, 911119, 11111, 41503, "abcd\\m4.bmp" },
                    { 77, 2, 4, 111111, 11111, 41503, "abcd\\m3.bmp" },
                    { 76, 1, 0, 911119, 91191, 41503, "abcd\\m2.bmp" },
                    { 109, 0, 0, 919999, 11999, 41500, "abcd\\oe000001.bmp" },
                    { 75, 1, 4, 911199, 11911, 41503, "abcd\\m1.bmp" },
                    { 90, 2, 0, 111111, 19919, 41503, "abcd\\ml000003.bmp" },
                    { 91, 2, 0, 119991, 19911, 41503, "abcd\\na000002.bmp" },
                    { 81, 2, 0, 911119, 11919, 41503, "abcd\\m7.bmp" },
                    { 93, 0, 0, 919999, 11999, 41500, "abcd\\nc000002.bmp" },
                    { 106, 0, 8, 911999, 99991, 41500, "abcd\\ns000001.bmp" },
                    { 92, 0, 0, 911999, 11999, 41500, "abcd\\nc000000.bmp" },
                    { 107, 0, 0, 911999, 99991, 41500, "abcd\\ns000002.bmp" },
                    { 105, 0, 0, 911919, 11999, 41500, "abcd\\ns000000.bmp" },
                    { 104, 1, 0, 911999, 11999, 41502, "abcd\\nk000010.bmp" },
                    { 103, 0, 0, 911999, 11999, 41502, "abcd\\nk000008.bmp" }
                });

            migrationBuilder.InsertData(
                table: "ExpertizerABCD",
                columns: new[] { "ID", "A_Score", "B_Score", "C_Score", "D_Score", "Diagnosis", "ImageID" },
                values: new object[,]
                {
                    { 101, 0, 0, 911999, 11919, 41502, "abcd\\nk000006.bmp" },
                    { 100, 1, 0, 911919, 11191, 41502, "abcd\\nk000004.bmp" },
                    { 102, 0, 0, 911999, 11991, 41502, "abcd\\nk000007.bmp" },
                    { 99, 0, 0, 911999, 11191, 41502, "abcd\\nk000003.bmp" },
                    { 98, 0, 0, 911999, 11199, 41502, "abcd\\nk000002.bmp" },
                    { 97, 0, 0, 911999, 11991, 41500, "abcd\\nc000007.bmp" },
                    { 96, 0, 0, 911999, 11999, 41500, "abcd\\nc000005.bmp" },
                    { 95, 0, 0, 911999, 11999, 41500, "abcd\\nc000004.bmp" },
                    { 94, 0, 0, 911999, 11999, 41500, "abcd\\nc000003.bmp" }
                });

            migrationBuilder.InsertData(
                table: "ExpertizerMain",
                columns: new[] { "ID", "ImageID", "LongDesc", "MainDX", "Method", "ShortDesc", "SubDX" },
                values: new object[,]
                {
                    { 137, "diagnose\\st000011.bmp", "A relatively large, symmetrical nevus with a sharp clinical margin. No pigment network. The main feature is a globular pattern without variegation throughout the lesion.", "NEV", 1, "Dermal Nevus", "DEN" },
                    { 143, "diagnose\\ur000007.bmp", "Main feature in this ellipsoid nevus is the regular pigment network, blurring in the central part of the lesion.", "NEV", 1, "Compound Nevus", "CON" },
                    { 135, "diagnose\\sh000005.bmp", "Comedo-like openings (dark globules) and milia-like cysts (white openings) are composing the \"gyriform\" appearance of this seborrheic keratosis. The lesion is sharply outlined. There is no pigment network. Note a small angioma at 6 o´clock position.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 138, "diagnose\\st000012.bmp", "This symmetrical lesion exhibits a sharp clinical margin, the pigmented structures are mainly arranged in a globular pattern. No pigment network discernible.", "NEV", 1, "Dermal Nevus", "DEN" },
                    { 139, "diagnose\\st000013.bmp", "A symmetrical nevus. The pigment network is discrete. Monomorphous general appearance. Some brown globules in the right part of the lesion.", "NEV", 1, "Compound Nevus", "CON" },
                    { 140, "diagnose\\st000019.bmp", "The nevus is of symmetrical shape. The margin is gradually and regularly fading towards the periphery. Regular pigment network.", "NEV", 1, "Compound Nevus", "CON" },
                    { 141, "diagnose\\st000022.bmp", "A  relatively large, symmetrical nevus with a relatively sharp clinical margin. No pigment network. The main feature is a globular pattern without pronounced variegation throughout the lesion.", "NEV", 1, "Compound Nevus", "CON" },
                    { 142, "diagnose\\tatoo.bmp", "Tattoos may mimic blue nevi.", "NON", 1, "ELM view of a tattoo", "OCX" },
                    { 136, "diagnose\\sh000070.bmp", "This small nevus shows a blurred, but discrete pigment network. The lesion is of symmetrical shape and the clinical margin is ill-defined.", "NEV", 1, "Compound nevus", "CON" },
                    { 144, "diagnose\\wa000012.bmp", "This symmetrical lesion exhibits a sharp clinical margin, the pigmented structures are mainly arranged in a globular pattern. No pigment network.", "NEV", 1, "Dermal Nevus", "DEN" },
                    { 151, "\\elm\\b108.bmp", "A regular pigment network is the main feature throughout the lesion. Mesh is regularly sized.", "PIGMENTNETWORK", 2, "Junctional nevus", "REGULARPIGMENTNETWORK" },
                    { 146, "\\elm\\1db.bmp", "Comedo-like openings as typical feature for seborrheic keratoses (yellow box). Horn cysts reaching the surface. Image made with High-definition system.", "COMEDO", 2, "Seborrheic keratosis", "COMEDO" },
                    { 147, "\\elm\\1ia.bmp", "Milia-like cysts as typical feature for seborrheic keratoses (yellow box). Horn cysts underneath the surface. Image made with High-definition system.", "MILIALIKE", 2, "Seborrheic keratosis", "MILIALIKE" },
                    { 148, "\\elm\\1ib.bmp", "Comedo-like openings as typical feature for seborrheic keratoses (yellow box). Horn cysts reaching the surface. Image made with High-definition system.", "COMEDO", 2, "Seborrheic keratosis", "COMEDO" },
                    { 149, "\\elm\\b107.bmp", "Pigment network appears inverted in the center of the lesion (arrow). Several irregular extensions (i.e. pseudopods) at the periphery.", "DEPIGMENTATION", 2, "Pigmented Spitz´s nevus", "RETICULAR" },
                    { 150, "\\elm\\b107a.bmp", "Multiple irregular extensions or pseudopods at the border of the lesion.", "PSEUDOPODS", 2, "Pigmented Spitz´s nevus", "PSEUDOPODS" },
                    { 152, "\\elm\\b110.bmp", "Typical example for a discrete pigment network.", "PIGMENTNETWORK", 2, "Junctional nevus", "DISCRETEPIGMENTNETWORK" },
                    { 153, "\\elm\\b112.bmp", "ELM reveals a regular, discrete, ill-defined pigment network. Note the sun damage around the lesion.", "PIGMENTNETWORK", 2, "Junctional nevus", "DISCRETEPIGMENTNETWORK" },
                    { 154, "\\elm\\b114.bmp", "The pigment network is ill-defined. Mesh size is wide (arrows).", "PIGMENTNETWORK", 2, "Junctional nevus", "WIDEPIGMENTNETWORK" },
                    { 134, "diagnose\\sh000004.bmp", "Comedo-like openings and milia-like cysts are composing the \"gyriform\" appearance of this seborrheic keratosis. The lesion is sharply outlined. There is no pigment network.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 156, "\\elm\\b11a.bmp", "Whitish veil as feature for advanced melanomas (yellow boxes).", "WHITISHVEIL", 2, "SSM, Breslow: 1,5 mm, Clark: IV", "WHITISHVEIL" },
                    { 155, "\\elm\\b116.bmp", "A typical example for a regular, well-defined pigment network.", "PIGMENTNETWORK", 2, "Junctional nevus", "REGULARPIGMENTNETWORK" },
                    { 145, "diagnose\\wd000001.bmp", "The dark globules in the center of the lesion are called comedo-like openings. The lesion is sharply demarcated. No pigment network.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 133, "diagnose\\sh000003.bmp", "This seborrheic keratosis is sharply outlined. No pigment network is discernible. Note the darker horny plugs resembling intraepidermal horn globules.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 116, "diagnose\\ml000004.bmp", "A symmetrical compound nevus with prominent pigment at the center. The clinical margins are well defined.", "NEV", 1, "Compound nevus", "CON" },
                    { 131, "diagnose\\sa000055.bmp", "A symmetrical lesion. Where discernible, the pigment network is regular and discrete. The clinical margin is ill-defined. Patchy hypopigmentation.", "NEV", 1, "Compound nevus", "CON" },
                    { 108, "diagnose\\jc000004.bmp", "Typical dermal nevus with almost perfect symmetry. The clinical margin is well-defined. Main features are a regular globular pattern and vascular loops at the periphery.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 157, "\\elm\\b11b.bmp", "Black dots varying in distribution and size are often found in melanomas (yellow box).", "BLACKDOTS", 2, "SSM, Breslow: 1,5 mm, Clark: IV", "BLACKDOTS" },
                    { 109, "diagnose\\jw000000.bmp", "A compound nevus with a delicate pigment network fading at the periphery. Central absence of pigment and capillary loops.", "NEV", 1, "Compound nevus", "CON" },
                    { 110, "diagnose\\ka000037.bmp", "This typical compound nevus shows only remnants of a regular and discrete pigment network at the periphery. The center of the lesion is composed of a patchy globular pattern.", "NEV", 1, "Compound nevus", "CON" },
                    { 111, "diagnose\\km000058.bmp", "A dermal nevus with faint globular structure. The clinical margins are well defined.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 112, "diagnose\\km000070.bmp", "Compound nevus without typical ELM features. The lesion is asymmetrical and exhibits central hyperpigmentation. The clinical margin is smoothly fading. These lesions are very common and rarely seen in textbooks.", "NEV", 1, "Compound nevus", "CON" },
                    { 113, "diagnose\\km000085.bmp", "A large compound nevus with a delicate pigment network fading at the periphery.", "NEV", 1, "Compound nevus", "CON" },
                    { 114, "diagnose\\lm000014.bmp", "Subungual hematoma. The toenail displays a broad pigment band without internal structures.", "NON", 1, "Hematoma subungual", "OCX" },
                    { 115, "diagnose\\me000008.bmp", "Seborrheic keratosis with some comedo-like openings at the periphery. The lesion may mimic a lesion with melanocytic origin. Note the complete absence of a pigment network.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 117, "diagnose\\mw000013.bmp", "A dermal nevus with faint globular structure. The clinical margins are well defined.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 118, "diagnose\\mw000016.bmp", "A compound nevus with a delicate pigment network. The clinical margins are well defined.", "NEV", 1, "Compound nevus", "CON" },
                    { 119, "diagnose\\nc000011.bmp", "Symmetrical lesion with a smoothly fading clinical margin. Main feature is a globular pattern. Central hypopigmentation.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 120, "diagnose\\nc000013.bmp", "A dermal nevus with faint globular structure. The clinical margins are well defined.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 121, "diagnose\\nc000014.bmp", "A dermal nevus with faint globular structure. The clinical margins are well defined.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 122, "diagnose\\nc000016.bmp", "A dermal nevus of ellipsoid shape. The clinical margins are well defined. The black globular structures represent horn cysts.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 123, "diagnose\\or000021.bmp", "This typical compound nevus shows only remnants of a regular and discrete pigment network at the periphery. The center of the lesion is composed of a patchy globular pattern. There is hypopigmentation in the right part of the lesion.", "NEV", 1, "Compound nevus", "CON" },
                    { 124, "diagnose\\pf000012.bmp", "A difficult diagnosis. This lesion is asymmetrical and exhibits remnants of a pigment network in the left part. Scarlike depigmentation of the remaining lesion may be a clue for the correct diagnosis.", "MEL", 1, "Melanoma of unclassifiable type; Breslow:0,8mm, Clark:III", "OMM" },
                    { 125, "diagnose\\pw000008.bmp", "A small, slightly asymmetrical lesion without classical ELM features. The clinical margin is ill-defined. Some brown globules in the left part of the lesion. No variegation of color.", "NEV", 1, "Compound nevus", "CON" },
                    { 126, "diagnose\\pw000010.bmp", "Compound nevus without typical ELM features. The lesion is symmetrical. The clinical margin is smoothly fading. These lesions are very common and rarely seen in textbooks.", "NEV", 1, "Compound nevus", "CON" },
                    { 127, "diagnose\\pw000011.bmp", "A small, symmetrical lesion without classical ELM features. The clinical margin is ill-defined. Some brown globules at the left and right pole of the lesion. No variegation of color.", "NEV", 1, "Compound nevus", "CON" },
                    { 128, "diagnose\\pw000012.bmp", "A small, symmetrical lesion with remnants of a pigment network at the 10 o´clock position. The clinical margin is ill-defined. No variegation of color.", "NEV", 1, "Compound nevus", "CON" },
                    { 129, "diagnose\\pw000013.bmp", "Compound nevus without typical ELM features. The lesion is slightly asymmetrical. The clinical margin is smoothly fading. These lesions are very common and rarely seen in textbooks.", "NEV", 1, "Compound nevus", "CON" },
                    { 130, "diagnose\\rc000012.bmp", "This typical compound nevus shows only remnants of a regular and discrete pigment network at the periphery. The center of the lesion is hyperpigmented.", "NEV", 1, "Compound nevus", "CON" },
                    { 132, "diagnose\\sa000058.bmp", "A slightly asymmetrical lesion. Where discernible, the pigment network is regular and discrete. The clinical margin is ill-defined. Patchy hyperpigmentation.", "NEV", 1, "Compound nevus", "CON" },
                    { 158, "\\elm\\b15a.bmp", "Typical example for a broad pigment network (highlighted rectangle).", "PIGMENTNETWORK", 2, "SSM, Breslow: 0,75 mm, Clark: III", "BROADPIGMENTNETWORK" },
                    { 193, "\\elm\\b36.bmp", "A rim of brown globules at the border of the lesion (arrows).", "BROWNGLOBULES", 2, "Dysplastic nevus", "BROWNGLOBULES" },
                    { 160, "\\elm\\b162.bmp", "Vascular lakes (arrows) in an angioma.", "REDBLUE", 2, "Angioma", "REDBLUE" },
                    { 188, "\\elm\\b26a.bmp", "Typical example for scarlike - depigmented areas in a melanoma with severe regression.", "DEPIGMENTATION", 2, "SSM, Breslow: 1,2 mm, Clark: III", "SCARLIKE" },
                    { 189, "\\elm\\b2a.bmp", "Example for black dots in an early melanoma (yellow box). Brown globules of different sizes in an haphazard distribution are displayed in the green box.", "BLACKDOTS", 2, "SSM, Breslow: 0,70 mm, Clark: IV", "BLACKDOTS" },
                    { 190, "\\elm\\b2a.bmp", "Brown globules of different sizes in an haphazard distribution are displayed in the green box. Example for black dots in an early melanoma (yellow box).", "BROWNGLOBULES", 2, "SSM, Breslow: 0,70 mm, Clark: IV", "BROWNGLOBULES" },
                    { 191, "\\elm\\b2b.bmp", "Example for radial streaming in an early melanoma (yellow box).", "RADIALSTREAMING", 2, "SSM, Breslow: 0,70 mm, Clark: IV", "RADIALSTREAMING" },
                    { 192, "\\elm\\b33a.bmp", "Example for pseudopods in an early superficial spreading melanoma (yellow box).", "PSEUDOPODS", 2, "SSM in situ", "PSEUDOPODS" },
                    { 194, "\\elm\\b37a.bmp", "Prominent and irregular pigment network (yellow box).", "PIGMENTNETWORK", 2, "Dysplastic nevus", "PROMINENTPIGMENTNETWORK" },
                    { 195, "\\elm\\b38a.bmp", "Example for a broad pigment network. The diameter of the mesh is wide.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "BROADPIGMENTNETWORK" },
                    { 196, "\\elm\\b41.bmp", "The general appearance of the pigment network is regular and discrete. Brown globules in the center of the lesion.", "PIGMENTNETWORK", 2, "Junctional nevus", "REGULARPIGMENTNETWORK" },
                    { 197, "\\elm\\b43.bmp", "The appearance of the pigment network is not homogeneously distributed throughout the lesion.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "IRREGULARPIGMENTNETWORK" },
                    { 198, "\\elm\\b43a.bmp", "Example for black dots in this dysplastic nevus (yellow box).", "BLACKDOTS", 2, "Dysplastic nevus", "BLACKDOTS" },
                    { 187, "\\elm\\b25a.bmp", "The yellow box marks a zone of radial streaming in an in situ melanoma.", "RADIALSTREAMING", 2, "SSM in situ", "RADIALSTREAMING" },
                    { 199, "\\elm\\b43b.bmp", "Broad rete ridges with intense pigmentation representing a broad pigment network (yellow boxes).", "PIGMENTNETWORK", 2, "Dysplastic nevus", "BROADPIGMENTNETWORK" },
                    { 201, "\\elm\\b4a.bmp", "This small gray blue area (yellow box) is an important diagnostic feature for the diagnosis of melanoma.", "GREYBLUE", 2, "SSM, Breslow: 0,35 mm, Clark:II", "GREYBLUE" },
                    { 202, "\\elm\\b53a.bmp", "Example for a narrow pigment network within the yellow box.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "NARROWPIGMENTNETWORK" },
                    { 203, "\\elm\\b83.bmp", "A rim of brown globules as clue feature for a pigmented Spitz’s nevus (arrows).", "BROWNGLOBULES", 2, "Pigmented Spitz´s nevus", "BROWNGLOBULES" },
                    { 204, "\\elm\\halo.bmp", "Halo phenomenon around a compound nevus with a slightly irregular pigment network.", "DEPIGMENTATION", 1, "Halo nevus (early stage)", "HYPOPIGMENTED" },
                    { 205, "\\elm\\hm000073.bmp", "A symmetrical lesion. The pigment network is delicate and partially blurred. The clinical margin is smoothly fading. Central hypopigmentation.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "DISCRETEPIGMENTNETWORK" },
                    { 206, "\\elm\\bm000173.bmp", "Diffuse pigmentation stands for the pattern of pigmentation of an entire lesion (Pehamberger et al., JID 100:365S-362S, 1993). In this example the pigmentation pattern, the diffuse pigmentation is very regular and gradually thins at the periphery.", "DEPIGMENTATION", 2, "Compound Nevus", "DIFFUSE" },
                    { 207, "\\elm\\gn000010.bmp", "Diffuse pigmentation stands for the pattern of pigmentation of an entire lesion (Pehamberger et al., JID 100:365S-362S, 1993). In this example the pigmentation pattern, the diffuse pigmentation is irregular and ends abruptly at the periphery of the lesion.", "DEPIGMENTATION", 2, "SSM, Breslow 1,0mm, Clark III", "DIFFUSE" },
                    { 208, "diagnose\\alm.bmp", "A plantar pigmented skin lesion. This asymmetrical lesion exhibits almost no abrupt ending of pigmentation at the periphery. Light brown, white, black and red are dominating colors. At the periphery (8 o´clock) a regular pigment network is discernible. Remnants of a prominent pigment network are found at the 5 o´clock position. A single but prominent brown globule is found at 12 o´ clock.", "MEL", 1, "ALM, Breslow 1,0 mm, Clark III", "ALM" },
                    { 209, "diagnose\\alm2.bmp", "This subungual lesion exhibits its pathognomonic features at the distal periphery where radial streaming is found. Colors vary form dark brown to black and dark blue. Also the nail matrix shows some involvement.", "MEL", 1, "ALM, Breslow 1.1 mm, Clark III", "ALM" },
                    { 107, "diagnose\\hm000073.bmp", "A symmetrical lesion. The pigment network is delicate and partially blurred. The clinical margin is smoothly fading. Central hypopigmentation.", "NEV", 1, "Compound nevus", "CON" },
                    { 200, "\\elm\\b45a.bmp", "Broad rete ridges with intense pigmentation representing a broad pigment network (yellow boxes).", "PIGMENTNETWORK", 2, "Dysplastic nevus", "BROADPIGMENTNETWORK" },
                    { 186, "\\elm\\b25.bmp", "Prominent pigment network in an in situ melanoma.", "PIGMENTNETWORK", 2, "SSM in situ", "PROMINENTPIGMENTNETWORK" },
                    { 185, "\\elm\\b22b.bmp", "Whitish veil in an early melanoma (yellow boxes).", "WHITISHVEIL", 2, "SSM, Breslow: 0,75 mm, Clark: III", "WHITISHVEIL" },
                    { 184, "\\elm\\b22a.bmp", "Prominent pigment network (yellow box) in an early melanoma.", "PIGMENTNETWORK", 2, "SSM, Breslow: 0,75 mm, Clark: III", "PROMINENTPIGMENTNETWORK" },
                    { 161, "\\elm\\b16a.bmp", "Hypopigmented areas are a common but often not specific feature in pigmented skin lesions (yellow box in this melanoma).", "DEPIGMENTATION", 2, "SSM, Breslow: 1,0 mm, Clark: III", "HYPOPIGMENTED" },
                    { 162, "\\elm\\b171.bmp", "Irregular pigment network in a dysplastic nevus.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "IRREGULARPIGMENTNETWORK" },
                    { 163, "\\elm\\b171a.bmp", "Example for black dots in a dysplastic nevus (yellow boxes).", "BLACKDOTS", 2, "Dysplastic nevus", "BLACKDOTS" },
                    { 164, "\\elm\\b173.bmp", "Irregular pigment network in a dysplastic nevus.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "IRREGULARPIGMENTNETWORK" },
                    { 165, "\\elm\\b173a.bmp", "Examples (yellow boxes) for a broad pigment network.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "BROADPIGMENTNETWORK" },
                    { 166, "\\elm\\b174a.bmp", "Examples (yellow boxes) for a broad pigment network.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "BROADPIGMENTNETWORK" },
                    { 167, "\\elm\\b176.bmp", "The main feature is the prominent, irregular pigment network which shows an abrupt border to the surrounding skin.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "PROMINENTPIGMENTNETWORK" },
                    { 168, "\\elm\\b176a.bmp", "Black dots at the periphery of the lesion (yellow boxes).", "BLACKDOTS", 2, "Dysplastic nevus", "BLACKDOTS" },
                    { 169, "\\elm\\b178.bmp", "A prominent, broad pigment network, mostly irregular with slight fading towards the periphery.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "BROADPIGMENTNETWORK" },
                    { 170, "\\elm\\b178.bmp", "The network is irregular in size as well as in pigmentation.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "IRREGULARPIGMENTNETWORK" },
                    { 171, "\\elm\\b178a.bmp", "Black dots of varying sizes are located mainly at the periphery of the lesion (yellow boxes).", "BLACKDOTS", 2, "Dysplastic nevus", "BLACKDOTS" },
                    { 172, "\\elm\\b17a.bmp", "White scar-like depigmented areas representing a zone of heavy regression.", "DEPIGMENTATION", 2, "SSM, Breslow: 0,9 mm, Clark: III", "SCARLIKE" },
                    { 173, "\\elm\\b180.bmp", "Brown globules of irregular distribution and size in a dysplastic nevus (marker).", "BROWNGLOBULES", 2, "Dysplastic nevus", "BROWNGLOBULES" },
                    { 174, "\\elm\\b182.bmp", "Irregular and prominent pigment network mainly in the periphery of a dysplastic nevus.", "PIGMENTNETWORK", 2, "Dysplastic nevus", "PROMINENTPIGMENTNETWORK" },
                    { 175, "\\elm\\b183.bmp", "Brown globules of varying sizes and irregular distribution as prominent features in a dysplastic nevus (yellow boxes).", "BROWNGLOBULES", 2, "Dysplastic nevus", "BROWNGLOBULES" },
                    { 176, "\\elm\\b184.bmp", "A typical example for blood vessels surrounding a pigmented basal cell carcinoma (arrows).", "TELANGIECTASIA", 2, "Pigmented basal cell carcinoma", "TELANGIECTASIA" },
                    { 177, "\\elm\\b187.bmp", "Telangiectasia in a basal cell carcinoma (arrow).", "TELANGIECTASIA", 2, "Pigmented basal cell carcinoma", "TELANGIECTASIA" },
                    { 178, "\\elm\\b189.bmp", "Telangiectasia in a basal cell carcinoma (arrow). Absence of pigment network.", "TELANGIECTASIA", 2, "Pigmented basal cell carcinoma", "TELANGIECTASIA" },
                    { 210, "diagnose\\nmm.bmp", "This nodular lesion consists of two parts. A central dark blue to black nodule and pink marginal rim. At first glance none of the typical features for melanoma is present. However, the combination of the dark central portion and the absence of red lacunae (indicating an angiomatous lesion) suggest the diagnosis of nodular melanoma.", "MEL", 1, "NMM, Brelsow 1.6 mm, Clark IV", "NMM" },
                    { 180, "\\elm\\b198a.bmp", "Maple leaf-like areas (yellow box) as important feature for this pigmented basal cell carcinoma.", "MAPLE", 2, "Pigmented basal cell carcinoma", "MAPLE" },
                    { 181, "\\elm\\b198.bmp", "Predominant feature is the massive telangiectasia (arrows) with ramification and kinking.", "TELANGIECTASIA", 2, "Pigmented basal cell carcinoma", "TELANGIECTASIA" },
                    { 182, "\\elm\\b20a.bmp", "Example for a whitish veil in a low-risk melanoma superficial spreading type (yellow box).", "WHITISHVEIL", 2, "SSM, Breslow: 0,75 mm, Clark: III", "WHITISHVEIL" },
                    { 183, "\\elm\\b20b.bmp", "Radial streaming (discrete) in a low-risk melanoma superficial spreading type (yellow box).", "RADIALSTREAMING", 2, "SSM, Breslow: 0,75 mm, Clark: III", "RADIALSTREAMING" },
                    { 159, "\\elm\\b161.bmp", "The lesion is mainly composed of black, globular structures without any pattern (arrows) representing thrombosed vessels and red-blue areas representing vessels with regular blood flow (yellow box).", "REDBLUE", 2, "Angioma", "REDBLUE" },
                    { 106, "diagnose\\hm000063.bmp", "Compound nevus without typical ELM features. The lesion is asymmetrical and exhibits central hypopigmentation. The clinical margin is smoothly fading. These lesions are very common and rarely seen in textbooks.", "NEV", 1, "Compound nevus", "CON" },
                    { 179, "\\elm\\b19.bmp", "Small lesion on the cheek of an elderly patient. Typical broad and prominent pigment network.", "PIGMENTNETWORK", 2, "LMM, Breslow: 0,3 mm, Clark II", "PROMINENTPIGMENTNETWORK" },
                    { 104, "diagnose\\gw000027.bmp", "Typical compound nevus without typical ELM features. The lesion is asymmetrical and exhibits central hypopigmentation. The clinical margin is smoothly fading. These lesions are very common and rarely seen in textbooks.", "NEV", 1, "Compound nevus", "CON" },
                    { 28, "diagnose\\b175.bmp", "A relatively large lesion with patchy hyper- and hypopigmentation. Central scarring is surrounded by an irregular pigment network. There is no abrupt ending of pigmentation at the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 29, "diagnose\\b176.bmp", "Using ELM this lesion may be diagnosed as dysplastic nevus or early melanoma with equal likelihood. Main features are a prominent, irregular pigment network, black dots at the periphery, the pigmentation is abruptly ending.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 30, "diagnose\\b178.bmp", "A small irregular lesion with the prominent features being its irregular, prominent pigment network and the black dots, which are of varying sizes. The large hyperpigmented area in the center is surrounded by patches of hypopigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 31, "diagnose\\b179.bmp", "A relatively small lesion presenting with different shades of brown. The pigment network is partly irregular and prominent.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 32, "diagnose\\b18.bmp", "We found this lesion extremely difficult. The general appearance reveals an irregular outline, asymmetry and different shades of brown. In addition, radial streaming and some black dots at the periphery suggest the diagnosis of an early melanoma.", "MEL", 1, "SSM, Breslow: 0,25 mm, Clark: II", "SSM" },
                    { 33, "diagnose\\b180.bmp", "Histologically diagnosed as dysplastic nevus this lesion shows brown globules of irregular distribution and size and an irregular pigmentation which gradually fades at the periphery. The hair follicle resembles a pseudo horn cyst.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 34, "diagnose\\b182.bmp", "ELM reveals an irregular and prominent pigment network mainly in the periphery of the lesion. The center shows an irregular, patchy pigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 35, "diagnose\\b184.bmp", "Pigmented basal cell carcinoma. Note the absence of network structures. There are multiple dilated vessels around the lesion.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 36, "diagnose\\b187.bmp", "Pigmented basal cell carcinoma. ELM fails to reveal a pigment network. Note the bluish-black lacunae and telangiectasia.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 37, "diagnose\\b188.bmp", "Small pigmented basal cell carcinoma. ELM fails to reveal network structures. In this case telangiectasia is a strong indicator for basal cell carcinoma.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 27, "diagnose\\b174.bmp", "A typical example for a dysplastic nevus. Main features are a broad and irregular pigment network. Patchy hypo- and hyperpigmentation. Note, there is no abrupt ending of pigmentation at the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 38, "diagnose\\b189.bmp", "Pigmented basal cell carcinoma with exulceration. This lesion may mimic melanoma. Note the absence of network structures.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 40, "diagnose\\b190.bmp", "ELM does not reveal network structures in this reddish blue lesion excluding melanoma.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 41, "diagnose\\b193.bmp", "Slowly growing lesion on the cheek of an elderly female patient. Note the complete absence of a pigment network. Multiple telangiectasia with kinky appearance around the lesion. Leaf-like pigmentation at three o’clock position.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 42, "diagnose\\b194.bmp", "A nodular lesion without pigment network structures. Multiple telangiectasia with kinky appearance around  and in the lesion. Leaf-like pigmentation at the center and at three o’clock position.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 43, "diagnose\\b198.bmp", "This pigmented lesion contains several typical features resembling basal cell carcinoma. Note the complete absence of a pigment network. Leaf-like pigmentation. Predominant feature is the massive telangiectasia with ramification and kinking.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 44, "diagnose\\b2.bmp", "SSM developing on a preexisting nevus. Note the two foci of growth in the northern and the south-western part of the lesion.", "MEL", 1, "SSM, Breslow: 0,70 mm, Clark: IV", "SSM" },
                    { 45, "diagnose\\b20.bmp", "Typical SSM with several features revealing the malignant nature of the pigmented skin lesion. Note the prominent pigment network, irregular extensions and the gray-blue veil in the center of the lesion.", "MEL", 1, "SSM, Breslow: 0,75 mm, Clark: III", "SSM" },
                    { 46, "diagnose\\b202.bmp", "This pigmented lesion contains several typical features resembling basal cell carcinoma. Note the complete absence of a pigment network. Leaf-like pigmentation. Predominant feature is the massive telangiectasia with ramification and kinking.", "NON", 1, "Pigmented basal cell carcinoma", "BCX" },
                    { 47, "diagnose\\b22.bmp", "Typical SSM with several features revealing the malignant nature of the pigmented skin lesion. Note the prominent pigment network, irregular extensions and the gray-blue veil in the center of the lesion.", "MEL", 1, "SSM, Breslow: 0,75 mm, Clark: IV", "SSM" },
                    { 48, "diagnose\\b23.bmp", "LMM on the face of a 58 year old male. The patient noted a loss of pigmentation and a decrease of size. This lesion exhibits severe regression. Note the  prominent pigment network in the southwestern portion of the lesion.", "MEL", 1, "LMM, Breslow: 0,3 mm, Clark: II", "LMM" },
                    { 49, "diagnose\\b25.bmp", "SSM in situ on the lower leg of a young female. Note the prominent, irregular pigment network and radial streaming in the eastern portion of the lesion.", "MEL", 1, "SSM in situ", "SSM" },
                    { 39, "diagnose\\b19.bmp", "A small LMM on the cheek of a 67 year old female patient. ELM reveals the typical, highly irregular pigment network. The mesh of the network structure is varying in size and shape.", "MEL", 1, "LMM, Breslow: 0,30 mm, Clark: II", "LMM" },
                    { 26, "diagnose\\b173.bmp", "Main features are spotty hyper- and hypopigmentation in irregular distribution. The pigment network shows different mesh-sizes throughout the lesion.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 25, "diagnose\\b172.bmp", "Main features are spotty hyper- and hypopigmentation in irregular distribution. ", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 24, "diagnose\\b171.bmp", "This pigmented skin lesion shows a highly irregular pigment network. Multiple black dots are irregularly distributed throughout the lesion.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 105, "diagnose\\hm000052.bmp", "Compound nevus without typical ELM features. The lesion is asymmetrical and exhibits central hypopigmentation. The clinical margin is smoothly fading. These lesions are very common and rarely seen in textbooks.", "NEV", 1, "Compound nevus", "CON" },
                    { 1, "diagnose\\b10.bmp", "A symmetrical lesion, with the border fading in seven segments. Four different colors can be seen, white light brown, dark brown and black. A pigment network, homogeneous area and globules as differential structures.", "MEL", 1, "SSM, Breslow: 0,7 mm, Clark: II", "SSM" },
                    { 2, "diagnose\\b106.bmp", "A lesion of almost perfect symmetry. There is an abrupt break-off of pigmentation at periphery. Light brown, darkbrown and black as colors. Brown globules and black dots as internal morphologic structures.", "NON", 1, "Pigmented Spitz´s nevus", "PSN" },
                    { 3, "diagnose\\b107.bmp", "A symmetrical skin lesion with an abrupt ending of pigmentation at the border. Black is the dominating color, globules the dominating structure component.", "NEV", 1, "Pigmented Spitz´s nevus", "PSN" },
                    { 4, "diagnose\\b108.bmp", "This junctional nevus is asymmetrical in one axis, the pigmentation is fading towards the periphery. Dominating colors are dark brown and light brown. Pigment network is discrete and homogeneous.", "NEV", 1, "Junctional nevus", "JUN" },
                    { 5, "diagnose\\b109.bmp", "An irregular nevus which shows asymmetry in both axes. The pigmentation cuts off sharply in six segments. Light brown and dark brown colored, the lesion shows a pigment network and a homogeneous area as differential structures.", "NEV", 1, "Junctional nevus", "JUN" },
                    { 6, "diagnose\\b110.bmp", "The lesion is symmetrical, the margins are well defined. The dominating color is light brown, the pigment network is discrete and regularly distributed.", "NEV", 1, "Junctional nevus", "JUN" },
                    { 7, "diagnose\\b111.bmp", "This nevus is almost completely symmetrical, the pigmentation fades towards the border. Light brown is the main color, an ill-defined network is the differential structure.", "NEV", 1, "Junctional nevus", "JUN" },
                    { 8, "diagnose\\b112.bmp", "A lesion which is slightly asymmetrical. The borders are well defined, the colors are light brown and dark brown. The pigment network is partially irregular.", "NEV", 1, "Junctional nevus", "JUN" },
                    { 9, "diagnose\\b137a.bmp", "A lesion without a pigment network. Comedo-like openings (yellow box).", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 10, "diagnose\\b138.bmp", "This very common lesion is symmetrical, the total absence of a pigment network is the diagnostic feature. Milia like cysts are another diagnostic criterion.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 11, "diagnose\\b139.bmp", "A typical lesion without a pigment network. The horncysts appear translucent.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 12, "diagnose\\b14.bmp", "A typical melanoma without symmetry. The pigment network is irregularly distributed. ", "MEL", 1, "SSM, Breslow: 0,25 mm, Clark: IV", "SSM" },
                    { 13, "diagnose\\b142.bmp", "Note the complete absence of pigmentation. The verrucous appearance is augmented by the light reflected from the edges in a different manner throughout the lesion.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 14, "diagnose\\b15.bmp", "An inhomogeneous pigment lesion. There is an abrupt ending of pigmentation. Note the pseudopods at 12 o´ clock.  An irregular pigment network and brown globules are further diagnostic features .", "MEL", 1, "SSM, Breslow: 0,75 mm, Clark: III", "SSM" },
                    { 15, "diagnose\\b158.bmp", "A peripheral rim of globules is the main diagnostic feature of this pigmented Spitz´s nevus.", "NEV", 1, "Pigmented Spitz´s nevus", "PSN" },
                    { 16, "diagnose\\b159.bmp", "A symmetrical pigmented skin lesion. The characteristic feature of this common blue nevus is the pigmentation that appears out of focus.", "NEV", 1, "Common blue nevus", "BLN" },
                    { 18, "diagnose\\b160.bmp", "A very common lesion with vascular loops as the main feature pointing towards the diagnosis of a cherry hemangioma.", "NON", 1, "Cherry hemangioma", "ANX" },
                    { 19, "diagnose\\b161.bmp", "A rather intriguing lesion irregular in shape. Although there is black at the center making this lesion suspicious, the diagnostic clue are the bluish-purple lakes that dominate the lesion and give away the diagnosis of angiokeratoma.", "NON", 1, "Angiokeratoma", "ANX" },
                    { 20, "diagnose\\b162.bmp", "The main features of this lesion are the purple lakes and the bluish streaks crossing the lesion.", "NON", 1, "Cherry hemangioma with thrombosis", "ANX" },
                    { 21, "diagnose\\b165.bmp", "Another typical cherry angioma with vascular lakes as the dominating feature.", "NON", 1, "Large cherry hemangioma", "ANX" },
                    { 22, "diagnose\\b167.bmp", "At the center of this lesion you can see the prominent artery feeding this spider angioma.", "NON", 1, "Spider nevus", "ANX" },
                    { 23, "diagnose\\b17.bmp", "An irregular pigment lesion with massive regression at the center. Note the black dots distributed in an haphazard pattern.", "MEL", 1, "SSM, Breslow: 0,9 mm, Clark: III", "SSM" },
                    { 50, "diagnose\\b26.bmp", "SSM with severe regression. Typical features are prominent and irregular pigment network, black dots of varying size and distribution.", "MEL", 1, "SSM, Breslow: 1,2 mm, Clark: III", "SSM" },
                    { 51, "diagnose\\b30.bmp", "Main features are spotty hyper- and hypopigmentation in irregular distribution. Where discernible, the pigment network is irregularly distributed.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 17, "diagnose\\b16.bmp", "A highly suspicious looking lesion. The pigment network is irregular in size and distribution. Brown globules can be seen at the left side of the lesion. A blue-gray area is another diagnostic clue.", "MEL", 1, "SSM, Breslow: 1,0 mm, Clark: III", "SSM" },
                    { 53, "diagnose\\b33.bmp", "A small pigmented skin lesion without pronounced asymmetry. However, general appearance suggests the diagnosis of melanoma. Main features are radial streaming (northern part), pseudopods (southern part), an irregular pigment network and zones of hypopigmentation.", "MEL", 1, "SSM in situ", "SSM" },
                    { 81, "diagnose\\b70.bmp", "ELM reveals a prominent, irregular pigment network. The pigmentation shows a tendency to end abruptly at the border in the right portion of the lesion. However, most of the border is fading towards the periphery. At the center there is a large patch of irregular hyperpigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 82, "diagnose\\b72.bmp", "An asymmetrical lesion with patchy hyper- and hypopigmentation. The network structure is prominent and irregular at the center. The outline of the lesion is irregular.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 83, "diagnose\\b74.bmp", "The lesion is asymmetrical with patchy hyper- and hypopigmentation. The network structure is prominent. The outline of the nevus is irregular.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 84, "diagnose\\b76.bmp", "Interesting pigmented skin lesion presenting a pronounced asymmetry. The border is abruptly ending in the lower right sector. The remaining clinical margin is gradually fading towards the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 85, "diagnose\\b77.bmp", "This lesion is symmetrical. The general appearance is uniform. No pigment network. The border is well-defined.", "NEV", 1, "Common blue nevus", "BLN" },
                    { 86, "diagnose\\b78.bmp", "A uniform appearing lesion with almost perfect symmetry. No pigment network. The border is well defined. The color is homogeneously blue-gray to brown-gray.", "NEV", 1, "Common blue nevus", "BLN" },
                    { 87, "diagnose\\b79.bmp", "A regular appearing lesion with almost perfect symmetry. No pigment network. The border is well defined. The color is homogeneously blue-gray to brown-gray.", "NEV", 1, "Common blue nevus", "BLN" },
                    { 88, "diagnose\\b80.bmp", "A regular appearing lesion with almost perfect symmetry. No pigment network. The border is well defined. The color is homogeneously blue-gray to brown-gray.", "NEV", 1, "Common blue nevus", "BLN" },
                    { 89, "diagnose\\b81.bmp", "This lesion shows slight asymmetry and a variegation of color ranging from blue to gray. The border of the nevus is ill-defined. A pigment network is not discernible.", "NEV", 1, "Combined nevus", "BLN" },
                    { 90, "diagnose\\b83.bmp", "The shape of the pigmented skin lesion is quite symmetrical. The clinical margin is well-defined, the pigmentation stops abruptly at periphery around the entire circumference. A peripheral rim of brown globules is the clue feature for the correct diagnosis.", "NEV", 1, "Pigmented Spitz´s nevus", "PSN" },
                    { 91, "diagnose\\bg000013.bmp", "The lesion exhibits a symmetrical shape. The pigment network is regular, but blurred. Patchy hypopigmentation in the periphery. The clinical margin is gradually fading towards the periphery.", "NEV", 1, "Compound nevus", "CON" },
                    { 92, "diagnose\\bg000020.bmp", "The lesion exhibits a symmetrical shape. Pigment network is not visible. Patchy hypopigmentation at the periphery.", "NEV", 1, "Compound nevus", "CON" },
                    { 93, "diagnose\\bg000026.bmp", "The lesion exhibits a symmetrical shape. Pigment network is not visible. The clinical margin is gradually fading towards the border.", "NEV", 1, "Compound nevus", "CON" },
                    { 95, "diagnose\\cong.bmp", "This small, symmetrical pigmented skin lesion is heavily pigmented. The network structure is prominent, the pigmentation is abruptly ending at the periphery.", "NEV", 1, "Small congenital melanocytic nevus", "CGN" },
                    { 96, "diagnose\\dr000001.bmp", "The fingernail displays a narrow, pigmented band. The color within this band is light brown. Biopsy was performed and revealed a compound nevus originating form the nail matrix.", "NON", 1, "Melanonychia striata", "OCX" },
                    { 97, "diagnose\\fd000045.bmp", "This homogeneously appearing lesion exhibits a symmetrical shape.  Pigment network is not visible. Patchy hypopigmentation at the periphery. The clinical margin is gradually fading towards the border.", "NEV", 1, "Compound nevus", "CON" },
                    { 98, "diagnose\\fd000046.bmp", "This typical compound nevus shows only remnants of a regular and discrete pigment network at the periphery. The center of the lesion is composed of a patchy globular pattern.", "NEV", 1, "Compound nevus", "CON" },
                    { 99, "diagnose\\fd000062.bmp", "This typical compound nevus shows only remnants of a regular and discrete pigment network at the periphery. The center of the lesion is composed of a patchy globular pattern.", "NEV", 1, "Compound nevus", "CON" },
                    { 100, "diagnose\\fd000064.bmp", "A symmetrical lesion. The clinical margin is well-defined. Main feature is a regular globular pattern. Capillary loops at the periphery.", "NEV", 1, "Dermal nevus", "DEN" },
                    { 101, "diagnose\\fd000069.bmp", "This relatively large compound nevus shows only remnants of a pigment network at the periphery. The center of the lesion is composed of a patchy globular pattern. The reddish hue is due to mechanical irritation.", "NEV", 1, "Compound nevus", "CON" },
                    { 102, "diagnose\\fm000026.bmp", "A symmetrical lesion. The clinical margin is well-defined. Main feature is a regular globular pattern.", "NEV", 1, "Compound nevus", "CON" },
                    { 52, "diagnose\\b32.bmp", "Pigmented skin lesion with asymmetry and different shades of brown. The dark spot makes the lesion suspicious looking. Don’t be confused by the circular blue line caused by a ball pen signifying the physician´s intention to treat.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 103, "diagnose\\gs000026.bmp", "A symmetrical lesion. The clinical margin is fading towards the periphery. The center of the lesion is heavily pigmented.", "NEV", 1, "Compound nevus", "CON" },
                    { 80, "diagnose\\b7.bmp", "Superficial spreading melanoma with nodular portion. The patient recognized a fast growing lesion. In the right part of the lesion remnants of a prominent, irregular pigment network. Some pseudopods (six o´clock position).", "MEL", 1, "SSM, Breslow:1,3 mm, Clark: IV", "SSM" },
                    { 79, "diagnose\\b68.bmp", "The patient explained that the lesion increased in size and shape during the last month. In fact, morphologically the asymmetrical nevus exhibits three foci of activity (8 o´clock, 11 o´clock and 3 o´clock). Partially the pigment network is prominent.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 94, "diagnose\\bh000003.bmp", "This ellipsoid lesion is sharply demarcated. The surface exhibits several horny plugs and cysts. A pigment network is not discernible.", "NON", 1, "Seborrheic keratosis", "SEX" },
                    { 77, "diagnose\\b65.bmp", "The symmetrical lesion exhibits a prominent pigment network. Black dots in irregular distribution and patchy hypopigmentation in the center as main features for diagnosing a dysplastic nevus with severe atypia.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 55, "diagnose\\b36.bmp", "Symmetric lesion with a peripheral rim of brown globules. Irregular dark pigment patches at the center of the lesion.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 54, "diagnose\\b35.bmp", "Symmetric lesion with pigment variegation. Main features are an irregular pigment network and central dark patches.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 78, "diagnose\\b66.bmp", "Main features for the diagnosis are an irregular, prominent pigment network and patchy hyperpigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 56, "diagnose\\b37.bmp", "The symmetrical lesion exhibits foci of prominent and irregular pigment network. There is no abrupt ending of pigmentation at the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 57, "diagnose\\b38.bmp", "Dysplastic nevus with pigment variegation, broad and prominent pigment network and some black dots at the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 58, "diagnose\\b41.bmp", "ELM reveals a symmetrical lesion with a prominent and irregular pigment network. The margins are ill-defined. Spotty hypopigmentation at the six o´clock and the eight o´clock position.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 59, "diagnose\\b43.bmp", "ELM reveals an asymmetrical, relatively large lesion. The pigment network is prominent and irregular. Black dots in irregular distribution in the left part of the lesion. Foci of spotty hypopigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 61, "diagnose\\b46.bmp", "Dysplastic nevus with an irregular pigment network gradually fading at the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 62, "diagnose\\b47.bmp", "A large dysplastic nevus with an irregular pigment network which fades gradually at the periphery. Foci of spotty hypopigmentation in the center of the lesion.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 63, "diagnose\\b48.bmp", "A small irregular lesion with marked hypopigmentation at the center, black dots of different sizes and patchy hyperpigmentation. The whole lesion seems to fade towards the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 64, "diagnose\\b49.bmp", "ELM reveals a prominent, irregular pigment network. Besides patches of hyperpigmentation there are some circular spots of hypopigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 65, "diagnose\\b50.bmp", "A dysplastic nevus with hypopigmentation as the dominant feature. Patchy hyperpigmentation in the center. There is a gradual fading of the lesion towards the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 60, "diagnose\\b45.bmp", "ELM reveals an asymmetrical lesion. The pigment network is prominent and irregular. Foci of spotty hypopigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 67, "diagnose\\b52.bmp", "ELM shows a prominent, irregular pigment network. Hypopigmentation in the center. Note the black dots of different form and size at the periphery.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 68, "diagnose\\b53.bmp", "ELM shows a prominent, irregular pigment network. There is an abrupt border as well as a fading at the periphery. At the center a large patch of irregular hyperpigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 69, "diagnose\\b54.bmp", "This small dysplastic nevus shows a prominent, irregular pigment network. At the center and at two o’clock there are two prominent patches of irregular hyperpigmentation.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 70, "diagnose\\b55.bmp", "A small pigmented skin lesion with the dominant features being the prominent patches of irregular hyperpigmentation as well as hypopigmentation in the center. Note how the pigmentation fades between 10 and 3 o’clock.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 71, "diagnose\\b56.bmp", "Irregular pigment network, patches of hypopigmentation. Discrete black dots at the periphery between 4 and 6 o’clock and between 9 and 11 o’clock.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 72, "diagnose\\b57.bmp", "A difficult lesion to diagnose. The prominent feature is the large plaque of irregular hyperpigmentation. Black dots of irregular distribution, brown globules of different sizes.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 73, "diagnose\\b58.bmp", "The lesion is asymmetrical. In the right portion the pigment network is prominent and irregular.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 76, "diagnose\\b62.bmp", "Pigment network is prominent and irregular in at least three regions in this asymmetrical lesion. In addition, black dots are seen in irregular distribution throughout the lesion.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 66, "diagnose\\b51.bmp", "ELM reveals brown globules of varying sizes located at the periphery of the lesion. There are many shades of brown as well as a reddish hue in the center.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 75, "diagnose\\b61.bmp", "The symmetrical lesion exhibits a wide and prominent pigment network. Black dots in irregular distribution and patchy hypopigmentation in the center as main features for diagnosing a dysplastic nevus with severe atypia.", "NEV", 1, "Dysplastic nevus", "DYN" },
                    { 74, "diagnose\\b6.bmp", "A large irregular lesion with the prominent feature being the black dots of different sizes in an haphazard distribution in the lower half of the lesion. Note the milky way and the whitish veil covering most part of the hyperpigmentation.", "MEL", 1, "SSM, Breslow: 0,80 mm, Clark: III", "SSM" }
                });

            migrationBuilder.InsertData(
                table: "ExpertizerS7",
                columns: new[] { "ID", "Diagnosis", "ImageID", "S1", "S2", "S3", "S4", "S5", "S6", "S7" },
                values: new object[,]
                {
                    { 197, 41502, "s7\\wt000015.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 196, 41502, "s7\\wt000014.bmp", 2, 0, 0, 0, 0, 0, 0 },
                    { 195, 41500, "s7\\wr000016.bmp", 0, 0, 0, 0, 0, 0, 0 },
                    { 194, 41500, "s7\\wh000001.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 193, 41503, "s7\\wg000002.bmp", 4, 1, 0, 0, 1, 2, 1 },
                    { 189, 41502, "s7\\we000005.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 191, 41502, "s7\\we000007.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 190, 41502, "s7\\we000006.bmp", 3, 0, 0, 0, 0, 1, 0 },
                    { 188, 41502, "s7\\we000004.bmp", 3, 0, 0, 0, 0, 2, 0 },
                    { 187, 41502, "s7\\we000003.bmp", 2, 0, 0, 0, 0, 2, 0 },
                    { 185, 41500, "s7\\wd000024.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 198, 41502, "s7\\wt000018.bmp", 3, 0, 0, 0, 0, 0, 0 },
                    { 186, 41500, "s7\\wd000025.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 192, 41502, "s7\\we000008.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 199, 41502, "s7\\wt000021.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 210, 41500, "s7\\be000060.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 201, 41502, "s7\\zw000009.bmp", 2, 0, 0, 0, 0, 0, 0 },
                    { 216, 41502, "s7\\bm000382.bmp", 0, 0, 0, 0, 1, 1, 0 },
                    { 184, 41500, "s7\\wd000008.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 215, 41502, "s7\\bk000054.bmp", 1, 0, 0, 0, 0, 2, 0 },
                    { 214, 41500, "s7\\bg000116.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 213, 41500, "s7\\bg000110.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 212, 41500, "s7\\bg000105.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 211, 41500, "s7\\bg000104.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 209, 41500, "s7\\be000059.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 208, 41500, "s7\\be000058.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 207, 41500, "s7\\bd000046.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 206, 41502, "s7\\ai000008.bmp", 0, 0, 1, 0, 0, 2, 1 },
                    { 205, 41502, "s7\\ai000006.bmp", 1, 0, 0, 2, 0, 2, 0 },
                    { 204, 41502, "s7\\ai000005.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 203, 41502, "s7\\ai000003.bmp", 0, 0, 0, 0, 1, 1, 0 },
                    { 202, 41502, "s7\\zw000010.bmp", 3, 0, 0, 2, 0, 1, 0 },
                    { 200, 41502, "s7\\wt000023.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 183, 41502, "s7\\wc000003.bmp", 0, 0, 0, 0, 0, 2, 0 },
                    { 158, 41500, "s7\\sm000029.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 181, 41500, "s7\\wa000004.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 161, 41500, "s7\\sr000019.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 160, 41502, "s7\\sr000013.bmp", 2, 0, 0, 0, 0, 0, 0 },
                    { 159, 41502, "s7\\sr000012.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 157, 41500, "s7\\sm000028.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 156, 41500, "s7\\sm000026.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 155, 41502, "s7\\sm000014.bmp", 2, 0, 0, 0, 0, 2, 0 },
                    { 162, 41500, "s7\\sr000020.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 154, 41503, "s7\\sm000010.bmp", 2, 1, 0, 2, 1, 2, 0 },
                    { 152, 41503, "s7\\sj000008.bmp", 4, 1, 0, 2, 1, 0, 0 },
                    { 151, 41503, "s7\\sj000003.bmp", 2, 0, 0, 2, 1, 2, 0 },
                    { 150, 41503, "s7\\sh000066.bmp", 0, 1, 1, 0, 0, 1, 1 },
                    { 149, 41502, "s7\\sh000024.bmp", 2, 0, 0, 0, 1, 2, 0 },
                    { 148, 41502, "s7\\sh000016.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 217, 41500, "s7\\bs000231.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 153, 41500, "s7\\sm000003.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 163, 41502, "s7\\sr000023.bmp", 1, 0, 0, 0, 1, 1, 0 },
                    { 164, 41502, "s7\\ss000000.bmp", 2, 0, 1, 0, 0, 1, 0 },
                    { 165, 41500, "s7\\ss000002.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 180, 41500, "s7\\vm000008.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 179, 41503, "s7\\tm000020.bmp", 2, 1, 1, 0, 0, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExpertizerS7",
                columns: new[] { "ID", "Diagnosis", "ImageID", "S1", "S2", "S3", "S4", "S5", "S6", "S7" },
                values: new object[,]
                {
                    { 178, 41500, "s7\\tm000012.bmp", 0, 0, 0, 0, 1, 0, 0 },
                    { 177, 41500, "s7\\tm000006.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 176, 41502, "s7\\tj000001.bmp", 1, 0, 0, 2, 0, 1, 0 },
                    { 175, 41502, "s7\\ti000001.bmp", 1, 0, 0, 0, 1, 0, 0 },
                    { 174, 41500, "s7\\ta000000.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 173, 41500, "s7\\sw000112.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 172, 41500, "s7\\sw000104.bmp", 0, 0, 0, 0, 0, 0, 0 },
                    { 171, 41500, "s7\\sw000103.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 170, 41502, "s7\\sw000039.bmp", 1, 0, 1, 0, 0, 0, 0 },
                    { 169, 41500, "s7\\sw000038.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 168, 41500, "s7\\st000000.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 167, 41502, "s7\\ss000041.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 166, 41502, "s7\\ss000006.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 182, 41500, "s7\\wc000001.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 218, 41502, "s7\\ca000472.bmp", 2, 0, 1, 0, 0, 0, 0 },
                    { 271, 41502, "s7\\le000034.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 220, 41503, "s7\\ci000020.bmp", 0, 1, 0, 2, 0, 0, 1 },
                    { 272, 41502, "s7\\nc000057.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 147, 41502, "s7\\sh000015.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 270, 41502, "s7\\le000032.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 269, 41500, "s7\\kk000201.bmp", 2, 0, 0, 2, 0, 0, 0 },
                    { 268, 41503, "s7\\kh000098.bmp", 4, 1, 0, 0, 0, 2, 0 },
                    { 267, 41502, "s7\\kg000212.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 273, 41502, "s7\\nc000058.bmp", 1, 1, 0, 0, 0, 0, 0 },
                    { 266, 41503, "s7\\kg000206.bmp", 2, 1, 0, 0, 1, 2, 0 },
                    { 264, 41502, "s7\\kg000202.bmp", 4, 0, 0, 0, 0, 1, 0 },
                    { 263, 41500, "s7\\kc000225.bmp", 2, 0, 0, 0, 1, 1, 0 },
                    { 262, 41503, "s7\\ka000163.bmp", 0, 1, 0, 2, 1, 2, 1 },
                    { 261, 41502, "s7\\js000008.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 260, 41502, "s7\\jr000129.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 259, 41502, "s7\\jr000126.bmp", 1, 0, 0, 0, 1, 1, 0 },
                    { 265, 41502, "s7\\kg000204.bmp", 0, 0, 0, 2, 0, 2, 0 },
                    { 274, 41502, "s7\\nc000059.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 275, 41502, "s7\\nc000060.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 276, 41502, "s7\\nc000061.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 291, 41503, "s7\\n9.bmp", 4, 0, 0, 2, 0, 1, 0 },
                    { 290, 41503, "s7\\n3.bmp", 0, 1, 1, 2, 0, 2, 0 },
                    { 289, 41503, "s7\\n13.bmp", 2, 0, 0, 2, 0, 2, 0 },
                    { 288, 41502, "s7\\n12.bmp", 4, 1, 0, 0, 1, 0, 0 },
                    { 287, 41503, "s7\\n11.bmp", 0, 1, 1, 2, 0, 2, 1 },
                    { 286, 41503, "s7\\n10.bmp", 4, 1, 0, 2, 0, 0, 1 },
                    { 285, 41502, "s7\\n1.bmp", 4, 0, 0, 2, 0, 0, 0 },
                    { 284, 41500, "s7\\pd000020.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 283, 41500, "s7\\pd000019.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 282, 41500, "s7\\os000028.bmp", 4, 0, 0, 0, 0, 1, 0 },
                    { 281, 41500, "s7\\nc000079.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 280, 41502, "s7\\nc000075.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 279, 41500, "s7\\nc000073.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 278, 41500, "s7\\nc000065.bmp", 1, 1, 0, 1, 0, 0, 0 },
                    { 277, 41502, "s7\\nc000062.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 258, 41500, "s7\\jm000054.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 219, 41502, "s7\\ca000483.bmp", 2, 0, 0, 0, 0, 0, 1 },
                    { 257, 41503, "s7\\jj000006.bmp", 4, 0, 0, 0, 0, 2, 0 },
                    { 255, 41500, "s7\\hr000099.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 234, 41502, "s7\\hb000113.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 233, 41502, "s7\\hb000112.bmp", 1, 0, 0, 2, 0, 1, 0 },
                    { 232, 41502, "s7\\hb000108.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 231, 41502, "s7\\hb000094.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 230, 41502, "s7\\hb000092.bmp", 2, 0, 0, 0, 1, 1, 0 },
                    { 229, 41502, "s7\\hb000089.bmp", 4, 0, 0, 0, 0, 2, 0 },
                    { 235, 41502, "s7\\hb000114.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 228, 41502, "s7\\ha000086.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 226, 41502, "s7\\er000090.bmp", 4, 0, 0, 0, 0, 0, 0 },
                    { 225, 41500, "s7\\er000085.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 224, 41503, "s7\\eb000057.bmp", 0, 1, 0, 2, 0, 2, 1 },
                    { 223, 41502, "s7\\ea000236.bmp", 0, 0, 1, 0, 0, 0, 0 },
                    { 222, 41502, "s7\\ea000231.bmp", 0, 0, 1, 0, 0, 1, 0 },
                    { 221, 41502, "s7\\ea000227.bmp", 0, 0, 1, 0, 0, 0, 0 },
                    { 227, 41502, "s7\\gh000044.bmp", 3, 0, 0, 0, 0, 0, 0 },
                    { 236, 41502, "s7\\hb000127.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 237, 41500, "s7\\hb000129.bmp", 1, 0, 0, 0, 0, 2, 0 },
                    { 238, 41502, "s7\\hb000133.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 254, 41502, "s7\\hr000095.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 253, 41502, "s7\\hp000079.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 252, 41500, "s7\\hm000344.bmp", 0, 0, 0, 0, 0, 0, 0 },
                    { 251, 41502, "s7\\hm000235.bmp", 4, 0, 0, 0, 0, 1, 0 },
                    { 250, 41502, "s7\\hj000160.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 249, 41502, "s7\\hh000173.bmp", 3, 0, 0, 0, 1, 1, 0 },
                    { 248, 41502, "s7\\hh000172.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 247, 41503, "s7\\hg000078.bmp", 4, 1, 1, 2, 0, 2, 1 },
                    { 245, 41500, "s7\\hf000082.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 244, 41502, "s7\\he000325.bmp", 2, 0, 0, 0, 1, 0, 0 },
                    { 243, 41503, "s7\\hc000135.bmp", 4, 0, 0, 2, 0, 2, 0 },
                    { 242, 41502, "s7\\hc000086.bmp", 4, 0, 0, 0, 0, 2, 0 },
                    { 241, 41500, "s7\\hc000084.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 240, 41500, "s7\\hc000080.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 239, 41502, "s7\\hc000079.bmp", 2, 0, 0, 0, 0, 2, 0 },
                    { 256, 41503, "s7\\jh000039.bmp", 4, 1, 0, 2, 0, 2, 1 },
                    { 146, 41502, "s7\\sh000013.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 246, 41500, "s7\\hf000083.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 144, 41500, "s7\\se000008.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 51, 41502, "s7\\kk000027.bmp", 1, 0, 1, 0, 0, 1, 1 },
                    { 50, 41500, "s7\\kk000024.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 49, 41503, "s7\\kj000125.bmp", 4, 1, 1, 0, 1, 2, 1 },
                    { 48, 41502, "s7\\kj000005.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 47, 41502, "s7\\kj000002.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 46, 41502, "s7\\kh000015.bmp", 1, 0, 0, 0, 1, 1, 0 },
                    { 52, 41502, "s7\\kk000031.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 45, 41500, "s7\\kg000036.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 43, 41502, "s7\\kf000064.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 42, 41502, "s7\\kb000044.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 41, 41502, "s7\\kb000004.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 40, 41502, "s7\\ka000014.bmp", 3, 0, 0, 0, 0, 1, 0 },
                    { 39, 41502, "s7\\jr000010.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 38, 41500, "s7\\jr000007.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 44, 41502, "s7\\kg000003.bmp", 2, 0, 0, 1, 0, 1, 0 },
                    { 36, 41502, "s7\\jr000005.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 53, 41503, "s7\\kk000094.bmp", 2, 1, 0, 0, 0, 2, 1 },
                    { 55, 41502, "s7\\km000016.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 69, 41503, "s7\\le000026.bmp", 2, 1, 0, 2, 1, 0, 1 },
                    { 68, 41500, "s7\\lc000002.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 67, 41500, "s7\\lc000000.bmp", 0, 0, 0, 0, 0, 2, 0 },
                    { 66, 41500, "s7\\kw000005.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 65, 41500, "s7\\kw000004.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 64, 41500, "s7\\kw000000.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 54, 41502, "s7\\km000015.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 63, 41502, "s7\\kn000017.bmp", 2, 1, 0, 0, 0, 1, 0 },
                    { 61, 41500, "s7\\kn000010.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 60, 41500, "s7\\kn000009.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 59, 41502, "s7\\kn000005.bmp", 3, 0, 0, 0, 0, 1, 0 },
                    { 58, 41502, "s7\\km000049.bmp", 0, 0, 0, 2, 0, 1, 0 },
                    { 57, 41502, "s7\\km000046.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 56, 41502, "s7\\km000033.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 62, 41502, "s7\\kn000015.bmp", 1, 0, 0, 0, 0, 2, 0 },
                    { 35, 41502, "s7\\jr000004.bmp", 0, 0, 0, 0, 1, 1, 0 },
                    { 34, 41502, "s7\\jr000002.bmp", 1, 0, 0, 0, 1, 1, 0 },
                    { 33, 41503, "s7\\jo000001.bmp", 0, 1, 1, 0, 1, 2, 1 },
                    { 13, 41503, "s7\\bp000005.bmp", 2, 0, 1, 0, 1, 2, 0 },
                    { 12, 41502, "s7\\a9.bmp", 1, 0, 0, 2, 0, 0, 0 },
                    { 11, 41502, "s7\\a8.bmp", 2, 1, 0, 0, 1, 2, 0 },
                    { 10, 41502, "s7\\a7.bmp", 1, 0, 0, 0, 0, 1, 1 },
                    { 9, 41502, "s7\\a6.bmp", 1, 1, 0, 0, 0, 0, 0 },
                    { 8, 41502, "s7\\a5.bmp", 3, 0, 1, 0, 0, 0, 0 },
                    { 14, 41500, "s7\\c1.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 7, 41502, "s7\\a3.bmp", 1, 1, 0, 0, 0, 0, 0 },
                    { 5, 41500, "s7\\a15.bmp", 1, 0, 0, 1, 0, 1, 0 },
                    { 4, 41500, "s7\\a14.bmp", 1, 0, 0, 1, 0, 1, 0 },
                    { 3, 41502, "s7\\a13.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 2, 41502, "s7\\a10.bmp", 2, 0, 0, 0, 0, 0, 0 },
                    { 1, 41502, "s7\\a1.bmp", 3, 1, 0, 1, 0, 0, 0 },
                    { 145, 41502, "s7\\se000011.bmp", 2, 0, 0, 0, 0, 0, 0 },
                    { 6, 41502, "s7\\a2.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 15, 41500, "s7\\c10.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 16, 41500, "s7\\c2.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 17, 41501, "s7\\c3.bmp", 0, 1, 0, 0, 0, 1, 0 },
                    { 32, 41503, "s7\\jj000004.bmp", 4, 0, 0, 2, 0, 1, 0 },
                    { 31, 41503, "s7\\hj000121.bmp", 0, 0, 1, 0, 1, 2, 0 },
                    { 30, 41503, "s7\\hj000115.bmp", 0, 1, 1, 0, 1, 2, 0 },
                    { 29, 41502, "s7\\he000233.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 28, 41502, "s7\\gs000129.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 27, 41503, "s7\\gf000001.bmp", 0, 1, 1, 2, 1, 2, 1 },
                    { 26, 41503, "s7\\fw000000.bmp", 0, 1, 1, 0, 1, 2, 1 },
                    { 25, 41502, "s7\\ds000021.bmp", 3, 0, 0, 2, 0, 1, 0 },
                    { 24, 41503, "s7\\de000007.bmp", 0, 0, 1, 2, 1, 2, 0 },
                    { 23, 41501, "s7\\c9.bmp", 1, 1, 0, 1, 0, 1, 0 },
                    { 22, 41500, "s7\\c8.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 21, 41502, "s7\\c7.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 20, 41502, "s7\\c6.bmp", 4, 0, 0, 0, 0, 0, 0 },
                    { 19, 41502, "s7\\c5.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 18, 41502, "s7\\c4.bmp", 2, 0, 1, 0, 0, 1, 0 },
                    { 70, 41503, "s7\\lg000013.bmp", 3, 1, 0, 2, 0, 2, 0 },
                    { 71, 41503, "s7\\lh000002.bmp", 4, 0, 0, 0, 0, 0, 0 },
                    { 37, 41502, "s7\\jr000006.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 73, 41502, "s7\\lt000000.bmp", 4, 0, 0, 0, 1, 0, 0 },
                    { 125, 41502, "s7\\pw000002.bmp", 1, 0, 0, 0, 0, 2, 0 },
                    { 123, 41502, "s7\\pp000064.bmp", 1, 0, 0, 0, 0, 2, 0 },
                    { 122, 41502, "s7\\pp000005.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 121, 41500, "s7\\pp000003.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 120, 41502, "s7\\pm000071.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 119, 41502, "s7\\pm000005.bmp", 1, 0, 0, 0, 1, 0, 0 },
                    { 126, 41502, "s7\\pw000003.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 118, 41502, "s7\\pl000005.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 116, 41500, "s7\\pf000001.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 115, 41502, "s7\\pb000009.bmp", 1, 0, 0, 0, 1, 1, 0 },
                    { 114, 41500, "s7\\pa000008.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 113, 41502, "s7\\pa000006.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 112, 41502, "s7\\pa000001.bmp", 2, 0, 0, 2, 1, 1, 0 },
                    { 111, 41502, "s7\\or000014.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 117, 41500, "s7\\pi000000.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 127, 41503, "s7\\pw000019.bmp", 4, 0, 0, 2, 0, 1, 0 },
                    { 128, 41502, "s7\\rb000013.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 129, 41502, "s7\\rb000028.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 143, 41500, "s7\\sb000066.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 72, 41500, "s7\\lm000036.bmp", 0, 0, 0, 0, 1, 1, 0 },
                    { 142, 41500, "s7\\sa000025.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 141, 41500, "s7\\sa000023.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 140, 41500, "s7\\sa000007.bmp", 0, 0, 0, 0, 0, 2, 0 },
                    { 139, 41500, "s7\\sa000000.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 138, 41500, "s7\\rh000000.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 137, 41502, "s7\\rf000087.bmp", 1, 0, 0, 0, 1, 1, 0 },
                    { 136, 41502, "s7\\rf000012.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 135, 41502, "s7\\rf000007.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 134, 41502, "s7\\rf000006.bmp", 1, 0, 0, 0, 1, 1, 0 },
                    { 133, 41502, "s7\\rf000004.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 132, 41502, "s7\\rf000001.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 131, 41502, "s7\\rf000000.bmp", 1, 0, 0, 0, 1, 2, 0 },
                    { 130, 41502, "s7\\rb000030.bmp", 2, 0, 0, 2, 0, 2, 0 },
                    { 110, 41502, "s7\\or000002.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 109, 41500, "s7\\oe000001.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 124, 41502, "s7\\ps000011.bmp", 2, 0, 0, 0, 1, 1, 0 },
                    { 107, 41500, "s7\\ns000002.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 88, 41500, "s7\\mg000004.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 87, 41502, "s7\\mf000002.bmp", 1, 0, 0, 0, 1, 0, 0 },
                    { 86, 41500, "s7\\md000004.bmp", 0, 0, 0, 1, 0, 0, 0 },
                    { 85, 41500, "s7\\md000002.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 84, 41500, "s7\\md000001.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 83, 41503, "s7\\m9.bmp", 0, 0, 1, 0, 0, 0, 1 },
                    { 82, 41503, "s7\\m8.bmp", 4, 1, 0, 0, 0, 2, 0 },
                    { 81, 41503, "s7\\m7.bmp", 4, 1, 0, 0, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExpertizerS7",
                columns: new[] { "ID", "Diagnosis", "ImageID", "S1", "S2", "S3", "S4", "S5", "S6", "S7" },
                values: new object[,]
                {
                    { 80, 41503, "s7\\m6.bmp", 4, 1, 0, 2, 0, 2, 1 },
                    { 79, 41503, "s7\\m5.bmp", 4, 0, 1, 2, 1, 0, 1 },
                    { 78, 41503, "s7\\m4.bmp", 4, 1, 0, 2, 0, 2, 0 },
                    { 77, 41503, "s7\\m3.bmp", 4, 1, 1, 2, 1, 2, 1 },
                    { 76, 41503, "s7\\m2.bmp", 4, 1, 0, 2, 0, 1, 0 },
                    { 108, 41502, "s7\\nt000006.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 74, 41502, "s7\\lt000001.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 89, 41500, "s7\\mg000007.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 90, 41503, "s7\\ml000003.bmp", 0, 1, 0, 0, 0, 2, 1 },
                    { 75, 41503, "s7\\m1.bmp", 2, 1, 0, 0, 0, 2, 0 },
                    { 92, 41500, "s7\\nc000000.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 91, 41503, "s7\\na000002.bmp", 0, 0, 1, 0, 0, 2, 1 },
                    { 105, 41500, "s7\\ns000000.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 104, 41502, "s7\\nk000010.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 103, 41502, "s7\\nk000008.bmp", 2, 0, 0, 0, 0, 0, 0 },
                    { 102, 41502, "s7\\nk000007.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 101, 41502, "s7\\nk000006.bmp", 2, 0, 0, 0, 0, 1, 0 },
                    { 100, 41502, "s7\\nk000004.bmp", 2, 0, 0, 2, 0, 1, 0 },
                    { 106, 41500, "s7\\ns000001.bmp", 0, 0, 0, 0, 0, 1, 0 },
                    { 98, 41502, "s7\\nk000002.bmp", 2, 0, 0, 2, 0, 0, 0 },
                    { 97, 41500, "s7\\nc000007.bmp", 1, 0, 0, 0, 0, 1, 0 },
                    { 96, 41500, "s7\\nc000005.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 95, 41500, "s7\\nc000004.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 94, 41500, "s7\\nc000003.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 93, 41500, "s7\\nc000002.bmp", 1, 0, 0, 0, 0, 0, 0 },
                    { 99, 41502, "s7\\nk000003.bmp", 2, 0, 0, 2, 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "ExpertizerSelf",
                columns: new[] { "ID", "Diag_Class", "Diagnosis", "ImageID" },
                values: new object[,]
                {
                    { 199, 2, 41502, "s7\\wt000021.bmp" },
                    { 198, 2, 41502, "s7\\wt000018.bmp" },
                    { 197, 2, 41502, "s7\\wt000015.bmp" },
                    { 196, 2, 41502, "s7\\wt000014.bmp" },
                    { 195, 1, 41500, "s7\\wr000016.bmp" },
                    { 194, 1, 41500, "s7\\wh000001.bmp" },
                    { 191, 2, 41502, "s7\\we000007.bmp" },
                    { 192, 2, 41502, "s7\\we000008.bmp" },
                    { 190, 2, 41502, "s7\\we000006.bmp" },
                    { 189, 2, 41502, "s7\\we000005.bmp" },
                    { 188, 2, 41502, "s7\\we000004.bmp" },
                    { 187, 2, 41502, "s7\\we000003.bmp" },
                    { 200, 2, 41502, "s7\\wt000023.bmp" },
                    { 186, 1, 41500, "s7\\wd000025.bmp" },
                    { 193, 3, 41503, "s7\\wg000002.bmp" },
                    { 201, 2, 41502, "s7\\zw000009.bmp" },
                    { 209, 1, 41500, "s7\\be000059.bmp" },
                    { 203, 2, 41502, "s7\\ai000003.bmp" },
                    { 185, 1, 41500, "s7\\wd000024.bmp" },
                    { 216, 2, 41502, "s7\\bm000382.bmp" },
                    { 215, 2, 41502, "s7\\bk000054.bmp" },
                    { 214, 1, 41500, "s7\\bg000116.bmp" },
                    { 213, 1, 41500, "s7\\bg000110.bmp" },
                    { 212, 1, 41500, "s7\\bg000105.bmp" },
                    { 202, 2, 41502, "s7\\zw000010.bmp" },
                    { 217, 1, 41500, "s7\\bs000231.bmp" },
                    { 210, 1, 41500, "s7\\be000060.bmp" },
                    { 208, 1, 41500, "s7\\be000058.bmp" },
                    { 207, 1, 41500, "s7\\bd000046.bmp" },
                    { 206, 2, 41502, "s7\\ai000008.bmp" },
                    { 205, 2, 41502, "s7\\ai000006.bmp" },
                    { 204, 2, 41502, "s7\\ai000005.bmp" },
                    { 211, 1, 41500, "s7\\bg000104.bmp" },
                    { 184, 1, 41500, "s7\\wd000008.bmp" },
                    { 149, 2, 41502, "s7\\sh000024.bmp" },
                    { 182, 1, 41500, "s7\\wc000001.bmp" },
                    { 162, 1, 41500, "s7\\sr000020.bmp" },
                    { 161, 1, 41500, "s7\\sr000019.bmp" },
                    { 160, 2, 41502, "s7\\sr000013.bmp" },
                    { 159, 2, 41502, "s7\\sr000012.bmp" },
                    { 158, 1, 41500, "s7\\sm000029.bmp" },
                    { 157, 1, 41500, "s7\\sm000028.bmp" },
                    { 163, 2, 41502, "s7\\sr000023.bmp" },
                    { 156, 1, 41500, "s7\\sm000026.bmp" },
                    { 154, 3, 41503, "s7\\sm000010.bmp" },
                    { 153, 1, 41500, "s7\\sm000003.bmp" },
                    { 152, 3, 41503, "s7\\sj000008.bmp" },
                    { 151, 3, 41503, "s7\\sj000003.bmp" },
                    { 150, 3, 41503, "s7\\sh000066.bmp" },
                    { 218, 2, 41502, "s7\\ca000472.bmp" },
                    { 155, 2, 41502, "s7\\sm000014.bmp" },
                    { 164, 2, 41502, "s7\\ss000000.bmp" },
                    { 165, 1, 41500, "s7\\ss000002.bmp" },
                    { 166, 2, 41502, "s7\\ss000006.bmp" },
                    { 181, 1, 41500, "s7\\wa000004.bmp" },
                    { 180, 1, 41500, "s7\\vm000008.bmp" },
                    { 179, 3, 41503, "s7\\tm000020.bmp" },
                    { 178, 1, 41500, "s7\\tm000012.bmp" },
                    { 177, 1, 41500, "s7\\tm000006.bmp" },
                    { 176, 2, 41502, "s7\\tj000001.bmp" },
                    { 175, 2, 41502, "s7\\ti000001.bmp" },
                    { 174, 1, 41500, "s7\\ta000000.bmp" },
                    { 173, 1, 41500, "s7\\sw000112.bmp" },
                    { 172, 1, 41500, "s7\\sw000104.bmp" },
                    { 171, 1, 41500, "s7\\sw000103.bmp" },
                    { 170, 2, 41502, "s7\\sw000039.bmp" },
                    { 169, 1, 41500, "s7\\sw000038.bmp" },
                    { 168, 1, 41500, "s7\\st000000.bmp" },
                    { 167, 2, 41502, "s7\\ss000041.bmp" },
                    { 183, 2, 41502, "s7\\wc000003.bmp" },
                    { 219, 2, 41502, "s7\\ca000483.bmp" },
                    { 291, 3, 41503, "s7\\n9.bmp" },
                    { 221, 2, 41502, "s7\\ea000227.bmp" },
                    { 272, 2, 41502, "s7\\nc000057.bmp" },
                    { 271, 2, 41502, "s7\\le000034.bmp" },
                    { 270, 2, 41502, "s7\\le000032.bmp" },
                    { 269, 1, 41500, "s7\\kk000201.bmp" },
                    { 268, 3, 41503, "s7\\kh000098.bmp" },
                    { 267, 2, 41502, "s7\\kg000212.bmp" },
                    { 273, 2, 41502, "s7\\nc000058.bmp" },
                    { 266, 3, 41503, "s7\\kg000206.bmp" },
                    { 264, 2, 41502, "s7\\kg000202.bmp" },
                    { 263, 1, 41500, "s7\\kc000225.bmp" },
                    { 262, 3, 41503, "s7\\ka000163.bmp" },
                    { 261, 2, 41502, "s7\\js000008.bmp" },
                    { 260, 2, 41502, "s7\\jr000129.bmp" },
                    { 259, 2, 41502, "s7\\jr000126.bmp" },
                    { 265, 2, 41502, "s7\\kg000204.bmp" },
                    { 274, 2, 41502, "s7\\nc000059.bmp" },
                    { 275, 2, 41502, "s7\\nc000060.bmp" },
                    { 276, 2, 41502, "s7\\nc000061.bmp" },
                    { 148, 2, 41502, "s7\\sh000016.bmp" },
                    { 290, 3, 41503, "s7\\n3.bmp" },
                    { 289, 3, 41503, "s7\\n13.bmp" },
                    { 288, 2, 41502, "s7\\n12.bmp" },
                    { 287, 3, 41503, "s7\\n11.bmp" },
                    { 286, 3, 41503, "s7\\n10.bmp" },
                    { 285, 2, 41502, "s7\\n1.bmp" },
                    { 284, 1, 41500, "s7\\pd000020.bmp" },
                    { 283, 1, 41500, "s7\\pd000019.bmp" },
                    { 282, 1, 41500, "s7\\os000028.bmp" },
                    { 281, 1, 41500, "s7\\nc000079.bmp" },
                    { 280, 2, 41502, "s7\\nc000075.bmp" },
                    { 279, 1, 41500, "s7\\nc000073.bmp" },
                    { 278, 1, 41500, "s7\\nc000065.bmp" },
                    { 277, 2, 41502, "s7\\nc000062.bmp" },
                    { 258, 1, 41500, "s7\\jm000054.bmp" },
                    { 220, 3, 41503, "s7\\ci000020.bmp" },
                    { 257, 3, 41503, "s7\\jj000006.bmp" },
                    { 255, 1, 41500, "s7\\hr000099.bmp" },
                    { 235, 2, 41502, "s7\\hb000114.bmp" },
                    { 234, 2, 41502, "s7\\hb000113.bmp" },
                    { 233, 2, 41502, "s7\\hb000112.bmp" },
                    { 232, 2, 41502, "s7\\hb000108.bmp" },
                    { 231, 2, 41502, "s7\\hb000094.bmp" },
                    { 230, 2, 41502, "s7\\hb000092.bmp" },
                    { 236, 2, 41502, "s7\\hb000127.bmp" },
                    { 229, 2, 41502, "s7\\hb000089.bmp" },
                    { 227, 2, 41502, "s7\\gh000044.bmp" },
                    { 226, 2, 41502, "s7\\er000090.bmp" },
                    { 225, 1, 41500, "s7\\er000085.bmp" },
                    { 224, 3, 41503, "s7\\eb000057.bmp" },
                    { 223, 2, 41502, "s7\\ea000236.bmp" },
                    { 222, 2, 41502, "s7\\ea000231.bmp" },
                    { 228, 2, 41502, "s7\\ha000086.bmp" },
                    { 237, 1, 41500, "s7\\hb000129.bmp" },
                    { 238, 2, 41502, "s7\\hb000133.bmp" },
                    { 239, 2, 41502, "s7\\hc000079.bmp" },
                    { 254, 2, 41502, "s7\\hr000095.bmp" },
                    { 253, 2, 41502, "s7\\hp000079.bmp" },
                    { 252, 1, 41500, "s7\\hm000344.bmp" },
                    { 251, 2, 41502, "s7\\hm000235.bmp" },
                    { 250, 2, 41502, "s7\\hj000160.bmp" },
                    { 249, 2, 41502, "s7\\hh000173.bmp" },
                    { 248, 2, 41502, "s7\\hh000172.bmp" },
                    { 247, 3, 41503, "s7\\hg000078.bmp" },
                    { 246, 1, 41500, "s7\\hf000083.bmp" },
                    { 245, 1, 41500, "s7\\hf000082.bmp" },
                    { 244, 2, 41502, "s7\\he000325.bmp" },
                    { 243, 3, 41503, "s7\\hc000135.bmp" },
                    { 242, 2, 41502, "s7\\hc000086.bmp" },
                    { 241, 1, 41500, "s7\\hc000084.bmp" },
                    { 240, 1, 41500, "s7\\hc000080.bmp" },
                    { 256, 3, 41503, "s7\\jh000039.bmp" },
                    { 147, 2, 41502, "s7\\sh000015.bmp" },
                    { 80, 3, 41503, "s7\\m6.bmp" },
                    { 145, 2, 41502, "s7\\se000011.bmp" },
                    { 51, 2, 41502, "s7\\kk000027.bmp" },
                    { 50, 1, 41500, "s7\\kk000024.bmp" },
                    { 49, 3, 41503, "s7\\kj000125.bmp" },
                    { 48, 2, 41502, "s7\\kj000005.bmp" },
                    { 47, 2, 41502, "s7\\kj000002.bmp" },
                    { 46, 2, 41502, "s7\\kh000015.bmp" },
                    { 52, 2, 41502, "s7\\kk000031.bmp" },
                    { 45, 1, 41500, "s7\\kg000036.bmp" },
                    { 43, 2, 41502, "s7\\kf000064.bmp" },
                    { 42, 2, 41502, "s7\\kb000044.bmp" },
                    { 41, 2, 41502, "s7\\kb000004.bmp" },
                    { 40, 2, 41502, "s7\\ka000014.bmp" },
                    { 39, 2, 41502, "s7\\jr000010.bmp" },
                    { 38, 1, 41500, "s7\\jr000007.bmp" },
                    { 44, 2, 41502, "s7\\kg000003.bmp" },
                    { 37, 2, 41502, "s7\\jr000006.bmp" },
                    { 53, 3, 41503, "s7\\kk000094.bmp" },
                    { 55, 2, 41502, "s7\\km000016.bmp" },
                    { 69, 3, 41503, "s7\\le000026.bmp" },
                    { 68, 1, 41500, "s7\\lc000002.bmp" },
                    { 67, 1, 41500, "s7\\lc000000.bmp" },
                    { 66, 1, 41500, "s7\\kw000005.bmp" },
                    { 146, 2, 41502, "s7\\sh000013.bmp" },
                    { 64, 1, 41500, "s7\\kw000000.bmp" },
                    { 54, 2, 41502, "s7\\km000015.bmp" },
                    { 63, 2, 41502, "s7\\kn000017.bmp" },
                    { 61, 1, 41500, "s7\\kn000010.bmp" },
                    { 60, 1, 41500, "s7\\kn000009.bmp" },
                    { 59, 2, 41502, "s7\\kn000005.bmp" },
                    { 58, 2, 41502, "s7\\km000049.bmp" },
                    { 57, 2, 41502, "s7\\km000046.bmp" },
                    { 56, 2, 41502, "s7\\km000033.bmp" },
                    { 62, 2, 41502, "s7\\kn000015.bmp" },
                    { 36, 2, 41502, "s7\\jr000005.bmp" },
                    { 35, 2, 41502, "s7\\jr000004.bmp" },
                    { 34, 2, 41502, "s7\\jr000002.bmp" },
                    { 14, 1, 41500, "s7\\c1.bmp" },
                    { 13, 3, 41503, "s7\\bp000005.bmp" },
                    { 12, 2, 41502, "s7\\a9.bmp" },
                    { 11, 2, 41502, "s7\\a8.bmp" },
                    { 10, 2, 41502, "s7\\a7.bmp" },
                    { 9, 2, 41502, "s7\\a6.bmp" },
                    { 15, 1, 41500, "s7\\c10.bmp" },
                    { 8, 2, 41502, "s7\\a5.bmp" },
                    { 6, 2, 41502, "s7\\a2.bmp" },
                    { 5, 1, 41500, "s7\\a15.bmp" },
                    { 4, 1, 41500, "s7\\a14.bmp" },
                    { 3, 2, 41502, "s7\\a13.bmp" },
                    { 2, 2, 41502, "s7\\a10.bmp" },
                    { 1, 2, 41502, "s7\\a1.bmp" },
                    { 7, 2, 41502, "s7\\a3.bmp" },
                    { 16, 1, 41500, "s7\\c2.bmp" },
                    { 17, 1, 41501, "s7\\c3.bmp" },
                    { 18, 2, 41502, "s7\\c4.bmp" },
                    { 33, 3, 41503, "s7\\jo000001.bmp" },
                    { 32, 3, 41503, "s7\\jj000004.bmp" },
                    { 31, 3, 41503, "s7\\hj000121.bmp" },
                    { 30, 3, 41503, "s7\\hj000115.bmp" },
                    { 29, 2, 41502, "s7\\he000233.bmp" },
                    { 28, 2, 41502, "s7\\gs000129.bmp" },
                    { 27, 3, 41503, "s7\\gf000001.bmp" },
                    { 26, 3, 41503, "s7\\fw000000.bmp" },
                    { 25, 2, 41502, "s7\\ds000021.bmp" },
                    { 24, 3, 41503, "s7\\de000007.bmp" },
                    { 23, 1, 41501, "s7\\c9.bmp" },
                    { 22, 1, 41500, "s7\\c8.bmp" },
                    { 21, 2, 41502, "s7\\c7.bmp" },
                    { 20, 2, 41502, "s7\\c6.bmp" },
                    { 19, 2, 41502, "s7\\c5.bmp" },
                    { 70, 3, 41503, "s7\\lg000013.bmp" },
                    { 71, 3, 41503, "s7\\lh000002.bmp" },
                    { 65, 1, 41500, "s7\\kw000004.bmp" },
                    { 73, 2, 41502, "s7\\lt000000.bmp" },
                    { 125, 2, 41502, "s7\\pw000002.bmp" },
                    { 124, 2, 41502, "s7\\ps000011.bmp" },
                    { 123, 2, 41502, "s7\\pp000064.bmp" },
                    { 122, 2, 41502, "s7\\pp000005.bmp" },
                    { 121, 1, 41500, "s7\\pp000003.bmp" },
                    { 120, 2, 41502, "s7\\pm000071.bmp" },
                    { 126, 2, 41502, "s7\\pw000003.bmp" },
                    { 119, 2, 41502, "s7\\pm000005.bmp" },
                    { 117, 1, 41500, "s7\\pi000000.bmp" },
                    { 72, 1, 41500, "s7\\lm000036.bmp" },
                    { 115, 2, 41502, "s7\\pb000009.bmp" },
                    { 114, 1, 41500, "s7\\pa000008.bmp" },
                    { 113, 2, 41502, "s7\\pa000006.bmp" },
                    { 112, 2, 41502, "s7\\pa000001.bmp" },
                    { 118, 2, 41502, "s7\\pl000005.bmp" },
                    { 127, 3, 41503, "s7\\pw000019.bmp" },
                    { 128, 2, 41502, "s7\\rb000013.bmp" },
                    { 129, 2, 41502, "s7\\rb000028.bmp" },
                    { 144, 1, 41500, "s7\\se000008.bmp" },
                    { 143, 1, 41500, "s7\\sb000066.bmp" },
                    { 142, 1, 41500, "s7\\sa000025.bmp" },
                    { 141, 1, 41500, "s7\\sa000023.bmp" },
                    { 140, 1, 41500, "s7\\sa000007.bmp" },
                    { 139, 1, 41500, "s7\\sa000000.bmp" },
                    { 138, 1, 41500, "s7\\rh000000.bmp" },
                    { 137, 2, 41502, "s7\\rf000087.bmp" },
                    { 136, 2, 41502, "s7\\rf000012.bmp" },
                    { 135, 2, 41502, "s7\\rf000007.bmp" },
                    { 134, 2, 41502, "s7\\rf000006.bmp" },
                    { 133, 2, 41502, "s7\\rf000004.bmp" },
                    { 132, 2, 41502, "s7\\rf000001.bmp" },
                    { 131, 2, 41502, "s7\\rf000000.bmp" },
                    { 130, 2, 41502, "s7\\rb000030.bmp" },
                    { 111, 2, 41502, "s7\\or000014.bmp" },
                    { 110, 2, 41502, "s7\\or000002.bmp" },
                    { 116, 1, 41500, "s7\\pf000001.bmp" },
                    { 108, 2, 41502, "s7\\nt000006.bmp" },
                    { 88, 1, 41500, "s7\\mg000004.bmp" },
                    { 87, 2, 41502, "s7\\mf000002.bmp" },
                    { 86, 1, 41500, "s7\\md000004.bmp" },
                    { 85, 1, 41500, "s7\\md000002.bmp" },
                    { 109, 1, 41500, "s7\\oe000001.bmp" },
                    { 83, 3, 41503, "s7\\m9.bmp" },
                    { 89, 1, 41500, "s7\\mg000007.bmp" },
                    { 82, 3, 41503, "s7\\m8.bmp" },
                    { 79, 3, 41503, "s7\\m5.bmp" },
                    { 78, 3, 41503, "s7\\m4.bmp" },
                    { 77, 3, 41503, "s7\\m3.bmp" },
                    { 76, 3, 41503, "s7\\m2.bmp" },
                    { 75, 3, 41503, "s7\\m1.bmp" },
                    { 74, 2, 41502, "s7\\lt000001.bmp" },
                    { 81, 3, 41503, "s7\\m7.bmp" },
                    { 90, 3, 41503, "s7\\ml000003.bmp" },
                    { 84, 1, 41500, "s7\\md000001.bmp" },
                    { 92, 1, 41500, "s7\\nc000000.bmp" },
                    { 91, 3, 41503, "s7\\na000002.bmp" },
                    { 106, 1, 41500, "s7\\ns000001.bmp" },
                    { 105, 1, 41500, "s7\\ns000000.bmp" },
                    { 104, 2, 41502, "s7\\nk000010.bmp" },
                    { 103, 2, 41502, "s7\\nk000008.bmp" },
                    { 102, 2, 41502, "s7\\nk000007.bmp" },
                    { 101, 2, 41502, "s7\\nk000006.bmp" },
                    { 107, 1, 41500, "s7\\ns000002.bmp" },
                    { 99, 2, 41502, "s7\\nk000003.bmp" },
                    { 98, 2, 41502, "s7\\nk000002.bmp" },
                    { 97, 1, 41500, "s7\\nc000007.bmp" },
                    { 96, 1, 41500, "s7\\nc000005.bmp" },
                    { 95, 1, 41500, "s7\\nc000004.bmp" },
                    { 94, 1, 41500, "s7\\nc000003.bmp" },
                    { 93, 1, 41500, "s7\\nc000002.bmp" },
                    { 100, 2, 41502, "s7\\nk000004.bmp" }
                });

            migrationBuilder.InsertData(
                table: "EyeColor",
                columns: new[] { "ID", "info" },
                values: new object[,]
                {
                    { 4, "Hazel" },
                    { 3, "Green" },
                    { 1, "Blue" },
                    { 2, "Brown" }
                });

            migrationBuilder.InsertData(
                table: "HairColor",
                columns: new[] { "ID", "info" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "Blonde" },
                    { 3, "Brown" },
                    { 4, "Dark Brown" },
                    { 5, "Red" },
                    { 6, "White" }
                });

            migrationBuilder.InsertData(
                table: "SkinColor",
                columns: new[] { "ID", "info" },
                values: new object[,]
                {
                    { 3, "Tan" },
                    { 1, "Brown" },
                    { 2, "Olive" },
                    { 4, "White" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aisinfo_patientId",
                table: "Aisinfo",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodymaps_patientId",
                table: "Bodymaps",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Camset_imageId",
                table: "Camset",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Closeup_imageId",
                table: "Closeup",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cosmetic_patientId",
                table: "Cosmetic",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_imageId",
                table: "Documents",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsHisto_histoId",
                table: "DocumentsHisto",
                column: "histoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpressImage_patientId",
                table: "ExpressImage",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Fup_imageId",
                table: "Fup",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Histos_patientId",
                table: "Histos",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_patientId",
                table: "Images",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgDiag_imageId",
                table: "ImgDiag",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Makro_imageId",
                table: "Makro",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Mikro_imageId",
                table: "Mikro",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Trichoscan_mikroId",
                table: "Trichoscan",
                column: "mikroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABCD");

            migrationBuilder.DropTable(
                name: "ActionLog");

            migrationBuilder.DropTable(
                name: "Aisinfo");

            migrationBuilder.DropTable(
                name: "Bodymaps");

            migrationBuilder.DropTable(
                name: "Camset");

            migrationBuilder.DropTable(
                name: "ChangedLoc");

            migrationBuilder.DropTable(
                name: "Closeup");

            migrationBuilder.DropTable(
                name: "Complexion");

            migrationBuilder.DropTable(
                name: "Cosmetic");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "DDSys");

            migrationBuilder.DropTable(
                name: "DEFBodymapPosition");

            migrationBuilder.DropTable(
                name: "DEFDiagnoses");

            migrationBuilder.DropTable(
                name: "DEFKen");

            migrationBuilder.DropTable(
                name: "DEFLocalTxt");

            migrationBuilder.DropTable(
                name: "DEFMakroKen");

            migrationBuilder.DropTable(
                name: "DEFMakroLokal");

            migrationBuilder.DropTable(
                name: "DEFMikroKen");

            migrationBuilder.DropTable(
                name: "DEFMikroLokal");

            migrationBuilder.DropTable(
                name: "DEFPublicDBFields");

            migrationBuilder.DropTable(
                name: "DEFPublicDBItems");

            migrationBuilder.DropTable(
                name: "DEFPublicDBTables");

            migrationBuilder.DropTable(
                name: "DEFSelectKen");

            migrationBuilder.DropTable(
                name: "DEFSmallKen");

            migrationBuilder.DropTable(
                name: "DEFSys");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Diagsource");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentsHisto");

            migrationBuilder.DropTable(
                name: "Ethnicgroup");

            migrationBuilder.DropTable(
                name: "ExpertizerABCD");

            migrationBuilder.DropTable(
                name: "ExpertizerMain");

            migrationBuilder.DropTable(
                name: "ExpertizerS7");

            migrationBuilder.DropTable(
                name: "ExpertizerSelf");

            migrationBuilder.DropTable(
                name: "ExpressImage");

            migrationBuilder.DropTable(
                name: "EyeColor");

            migrationBuilder.DropTable(
                name: "Fup");

            migrationBuilder.DropTable(
                name: "HairColor");

            migrationBuilder.DropTable(
                name: "ImgDiag");

            migrationBuilder.DropTable(
                name: "Makro");

            migrationBuilder.DropTable(
                name: "Mee");

            migrationBuilder.DropTable(
                name: "Mem");

            migrationBuilder.DropTable(
                name: "Memc");

            migrationBuilder.DropTable(
                name: "S7p");

            migrationBuilder.DropTable(
                name: "Sender");

            migrationBuilder.DropTable(
                name: "SkinColor");

            migrationBuilder.DropTable(
                name: "Timestamps");

            migrationBuilder.DropTable(
                name: "Trichoscan");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Histos");

            migrationBuilder.DropTable(
                name: "Mikro");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
