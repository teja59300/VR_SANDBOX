import React, { useContext } from 'react';
import { Item, Button, Label, Segment } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import ActivityStore from '../../../app/stores/activityStore';


 const ActivityList:React.FC= () => {
    const activityStore = useContext(ActivityStore);
    const {activitiesByDate, selectActivity, deleteActivity, submitting, target} = activityStore;
    return (
        <Segment clearing> 
            <Item.Group divided>
                {activitiesByDate.map(activity => (
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
                                    title = {activity.id}
                                    loading={target=== activity.id && submitting}
                                    onClick={(e) => deleteActivity(e,activity.id)} 
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
export default observer(ActivityList);