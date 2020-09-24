import React ,{useState, FormEvent}from 'react'
import { Segment, Form, Button } from 'semantic-ui-react'
import { IActivity } from '../../../app/models/activity'
import {v4 as uuid} from 'uuid';

interface IProps {
    setEditMode : (editMode : boolean) => void;
    activity : IActivity;
    createActvity:(activity:IActivity) => void;
    editActivity:(activity:IActivity) => void;
}

export const ActivityForm : React.FC<IProps> = 
    ({
        setEditMode,
        activity:initialFormState,
        createActvity,
        editActivity
    }) => {

    const initializeForm = () => {
        if (initialFormState) {
          return initialFormState;
        } else {
          return {
            id: '',
            name: '',
            address: '',
            description: '',
            date: '',
            phoneNumber: '',
            noOfAcres: '',
            amount: '',
            status: '',

          };
        }
      };
    const [activity , setActivity] = useState<IActivity>(initializeForm);

    const handleSubmit = () => {
        if(activity.id.length === 0)
        {
            let newActivity = {
                ...activity,
                id: uuid()
            }
            createActvity(newActivity);
        }
        else
        {
            editActivity(activity);
        }
    }

    const handleInputChange = (event:FormEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const {title,value} = event.currentTarget;
        setActivity({...activity,[title]:value})
    }
    return (
        <Segment clearing>
            <Form onSubmit={handleSubmit}> 
                <Form.Input 
                    onChange={handleInputChange} 
                    title='name' 
                    placeholder='Name' 
                    value={activity.name}
                />
                <Form.TextArea
                    onChange={handleInputChange} 
                    title='description'  
                    rows={2} 
                    placeholder='Description' 
                    value={activity.description}
                />
                <Form.Input 
                    onChange={handleInputChange} 
                    title='phoneNumber' 
                    placeholder='Phone Number' 
                    value={activity.phoneNumber}
                />
                <Form.Input 
                    onChange={handleInputChange} 
                    title='date' 
                    type='datetime-local' 
                    placeholder='Date' 
                    value={activity.date}
                />
                <Form.Input 
                    onChange={handleInputChange} 
                    title='address' 
                    placeholder='Address' 
                    value = {activity.address}
                />
                <Form.Input 
                    onChange={handleInputChange} 
                    title='noOfAcres' 
                    placeholder='NoOfAcres' 
                    value={activity.noOfAcres} 
                />
                <Form.Input 
                    onChange={handleInputChange} 
                    title='amount' 
                    placeholder='Amount' 
                    value={activity.amount} 
                />
                <Form.Input 
                    onChange={handleInputChange} 
                    title='status' 
                    placeholder='Status' 
                    value={activity.status} 
                />
                <Button 

                    floated='right'
                    positive type='submit' 
                    content='Submit'
                />
                <Button 
                    onClick={() => setEditMode(false)} 
                    floated='right' 
                    type='button' 
                    content='Cancel'
                />
            </Form>
        </Segment>
    )
}
