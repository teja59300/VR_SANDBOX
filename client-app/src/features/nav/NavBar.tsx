import React, { useContext } from 'react'
import { Menu, Container, Button } from 'semantic-ui-react'
import ActivityStore from '../../app/stores/activityStore';
import { observer } from 'mobx-react-lite';



export const NavBar : React.FC = () => {
    const activityStore = useContext(ActivityStore);
    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight:'10px'}}/>
                    VR9
                </Menu.Item>
                <Menu.Item name='Activities'/>
                <Menu.Item name='Financials'/>
                <Menu.Item>
                    <Button onClick={activityStore.openCreateForm} positive content='createActivity'/>
                </Menu.Item>
            </Container>
        </Menu>
        
    )
}
export default observer(NavBar);