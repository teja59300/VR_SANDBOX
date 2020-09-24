import React from 'react'
import { Item, Button, Label, Segment } from 'semantic-ui-react'
import { IActivity } from '../../../app/models/activity'
interface IProps {
    activities : IActivity[];
    selectActivity: (id:string) => void;
    deleteActivity:(id:string) => void;
}

export const ActivityList:React.FC<IProps>= ({
        activities,
        selectActivity,
        deleteActivity
    }) => {
    return (
        <Segment clearing> 
            <Item.Group divided>
                {activities.map(activity => (
                        <Item key={activity.id}>
                
                        <Item.Content>
                           <Item.Header as='a'>{activity.name}</Item.Header>
                           <Item.Meta>{activity.date}</Item.Meta>
                           <Item.Description>
                               <div>
                                   {activity.description}
                               </div>
                               <div>
                                   {activity.address}
                               </div>
                               <div>
                                   {activity.noOfAcres}
                               </div>
                               <div>
                                   {activity.amount}
                               </div>
                           </Item.Description>
                           <Item.Extra> 
                               <Button 
                                    onClick={() => selectActivity(activity.id)} 
                                    floated='right' 
                                    content='View' 
                                    color='blue'
                                />
                                <Button 
                                    onClick={() => deleteActivity(activity.id)} 
                                    floated='right' 
                                    content='Delete' 
                                    color='red'
                                />
                               <Label basic content={activity.status}/>
                           </Item.Extra>
                       </Item.Content>
                   </Item>
                ))}
        </Item.Group>
        </Segment>
            
    )
}
