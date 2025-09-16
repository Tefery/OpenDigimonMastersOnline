namespace ODMO.Commons.Enums
{
    public enum SkillCodeApplyTypeEnum
    {
        //TODO: identificar
        None = 0,
        Unknown1 = 1, //(PA-((AP*RD)*(DA*0.01)-(mde*(NA*0.01))+((AttackerLv-TargetLv)*10)))
        Unknown2 = 2, //PA-(((AP*RD)*(DA*0.01)+(PB+(skill_apply*skilllevel))-((mde*(NA*0.01))*Attackskill_atb*0.01))+((AttackerLv-TargetLv)*10))
        Unknown10 = 10, //(AT*PB)+[AT*{(1+Random/100)*PB}]-[{MD/(TLv/MLv)*100}*100]
        
        Default = 101, //A = A + B
        Percent = 102, //BA = BA + (BA×B÷100)
        AlsoPercent = 106, //+10%

        Unknown103 = 103, //RA = RA + (RA×B÷100)
        Unknown104 = 104, //A = B
        Unknown105 = 105, //A = A + (A×B÷100)
        Unknown107 = 107, //A = A - (B + (Lv×?????÷100))
        Unknown108 = 108, //A = A
        Unknown200 = 200, //???? ??
        Unknown201 = 201, //C??? A = A + B
        Unknown202 = 202, //B??? BA = BA + (BA×C÷100)
        Unknown203 = 203, //B??? RA = RA + (RA×C÷100)
        Unknown204 = 204, //B??? A = C
        Unknown205 = 205, //B + ((?? Lv - 1) *????)
        Unknown206 = 206, //B + ((?? Lv - 1) *????)
        Unknown207 = 207, //B + ((?? Lv - 1) *????)
        Unknown208 = 208, //Time_DamageS + ((Skill Lv - 1) *Increase value)
        Unknown301 = 301, //A = A - B
        Unknown302 = 302, //A = A - (AxB÷100)
        Unknown401 = 401, //B~C ??? ???
        Unknown402 = 402, //??? ??? ?? ??[????]
        Unknown403 = 403, //A = A + (Bx100)
        Unknown404 = 404 //A = A - (Bx100)
    }
}