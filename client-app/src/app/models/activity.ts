export interface IActivity 
{
    id:string,
    name:string,
    phoneNumber:string,
    status:string,
    description:string,
    address:string,
    date:Date,
    amount:string,
    noOfAcres:string
}

export interface IActivityFormValues extends Partial<IActivity> {
    time?:Date
}


export class ActivityFormValues implements IActivityFormValues {
    id?: string = undefined;
    name: string = '';
    address: string ='';
    description:string = '';
    date?: Date = undefined;
    time?: Date = undefined;
    phoneNumber: string ='';
    noOfAcres: string ='';
    amount: string = '';
    status: string = '';


    constructor(init? : IActivityFormValues) 
    {
        if(init && init.date) 
        {
            init.time = init.date
        }
        Object.assign(this,init);
    }
}